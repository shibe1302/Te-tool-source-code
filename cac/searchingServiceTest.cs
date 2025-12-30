using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TE_TOOL.CONFIG;
using TE_TOOL.Models;
using TE_TOOL.Services;

namespace cac
{
    internal class searchingServiceTest
    {
        private string _filePath; [SetUp]
        public void Setup()
        {
            _filePath = PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON;
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
        [Test]
        public void InitializeFile_ShouldCreateFile_WhenFileDoesNotExist()
        {
            // Act: khởi tạo service (constructor sẽ gọi InitializeFile)
            var service = new SearchingService();

            // Assert: File phải tồn tại
            Assert.That(File.Exists(_filePath), Is.True);

            // Assert: Nội dung file phải là danh sách rỗng
            string jsonContent = File.ReadAllText(_filePath);
            var products = JsonSerializer.Deserialize<List<ProductNameModel>>(jsonContent);
            Assert.That(products, Is.Not.Null);
            Assert.That(products, Is.Empty);
        }

        [Test]
        public void WriteToFile_ShouldWriteThreeProducts()
        {
            // Arrange: tạo danh sách 3 sản phẩm
            var products = new List<ProductNameModel>
            {
                new ProductNameModel { Model = "M001", ProductName = "Laptop A" },
                new ProductNameModel { Model = "M002", ProductName = "Laptop B" },
                new ProductNameModel { Model = "M003", ProductName = "Laptop C" }
            };

            var service = new SearchingService();

            // Act: ghi dữ liệu vào file
            service.WriteToFile(products);

            // Assert: kiểm tra file tồn tại
            Assert.That(File.Exists(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON), Is.True);

            // Đọc lại nội dung file
            string jsonContent = File.ReadAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON);
            var result = JsonSerializer.Deserialize<List<ProductNameModel>>(jsonContent);

            // Kiểm tra danh sách có đúng 3 phần tử
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));

            // Kiểm tra dữ liệu từng phần tử
            Assert.That(result[0].Model, Is.EqualTo("M001"));
            Assert.That(result[0].ProductName, Is.EqualTo("Laptop A"));

            Assert.That(result[1].Model, Is.EqualTo("M002"));
            Assert.That(result[1].ProductName, Is.EqualTo("Laptop B"));

            Assert.That(result[2].Model, Is.EqualTo("M003"));
            Assert.That(result[2].ProductName, Is.EqualTo("Laptop C"));
        }

        [Test]
        public void ReadFromFile_ShouldReturnEmptyList_WhenFileDoesNotExist()
        {
            var service = new SearchingService();
            var result = service.ReadFromFile();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ReadFromFile_ShouldReturnProducts_WhenFileHasData()
        {
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "M001", ProductName = "Laptop A" },
        new ProductNameModel { Model = "M002", ProductName = "Laptop B" },
        new ProductNameModel { Model = "M003", ProductName = "Laptop C" }
    };

            string jsonContent = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON, jsonContent);

            var service = new SearchingService();
            var result = service.ReadFromFile();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].ProductName, Is.EqualTo("Laptop A"));
            Assert.That(result[1].ProductName, Is.EqualTo("Laptop B"));
            Assert.That(result[2].ProductName, Is.EqualTo("Laptop C"));
        }

        [Test]
        public void AddProduct_ShouldAddNewProductToFile()
        {
          
            var service = new SearchingService();
            service.DeleteFile(); 
            var initialProducts = new List<ProductNameModel>();
            service.WriteToFile(initialProducts);

            var newProduct = new ProductNameModel
            {
                Model = "M100",
                ProductName = "Laptop Test"
            };

            // Act: thêm sản phẩm mới
            service.AddProduct(newProduct);

            // Assert: đọc lại file và kiểm tra
            var result = service.ReadFromFile();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Model, Is.EqualTo("M100"));
            Assert.That(result[0].ProductName, Is.EqualTo("Laptop Test"));
        }


        [Test]
        public void FindByModel_ShouldReturnNull_WhenModelDoesNotExist()
        {
            // Arrange: ghi sẵn dữ liệu vào file
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "M001", ProductName = "Laptop A" }
    };

            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON,
                JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true }));

            var service = new SearchingService();

            // Act: tìm sản phẩm không tồn tại
            var result = service.FindByModel("M999");

            // Assert: phải trả về null
            Assert.That(result, Is.Empty);
        }

    
        [Test]
        public void FindByProductName_ShouldReturnNull_WhenProductNameDoesNotExist()
        {
            // Arrange: ghi sẵn dữ liệu vào file
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "M001", ProductName = "Laptop A" }
    };

            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON,
                JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true }));

            var service = new SearchingService();

            // Act: tìm sản phẩm không tồn tại
            var result = service.FindByProductName("Laptop Z");

            // Assert: phải trả về null
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void LoadFromCsvOrTxt_ShouldLoadDataWithoutQuotes()
        {
            // Arrange: tạo file txt giả lập
            string tempTxtPath = Path.Combine(Path.GetTempPath(), "products_data.txt");
            string[] lines =
            {
        "PC101, laptop A",
        "PC102, laptop B",
        "PC103, laptop C"
    };
            File.WriteAllLines(tempTxtPath, lines);

            var fileJsonData= PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON;
            if (File.Exists(fileJsonData))
            {
                File.Delete(fileJsonData);
            }

            var service = new SearchingService();

            // Act
            service.LoadFromCsvOrTxt(tempTxtPath);

            // Assert
            var result = service.ReadFromFile();

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].Model, Is.EqualTo("PC101"));
            Assert.That(result[0].ProductName, Is.EqualTo("laptop A"));
            Assert.That(result[1].Model, Is.EqualTo("PC102"));
            Assert.That(result[1].ProductName, Is.EqualTo("laptop B"));
            Assert.That(result[2].Model, Is.EqualTo("PC103"));
            Assert.That(result[2].ProductName, Is.EqualTo("laptop C"));
        }
        [Test]
        public void FindByModel_ShouldReturnAll_WhenInputIsEmpty()
        {
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "PC101", ProductName = "Laptop A" },
        new ProductNameModel { Model = "PC102", ProductName = "Laptop B" }
    };

            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON,
                JsonSerializer.Serialize(products));

            var service = new SearchingService();
            var result = service.FindByModel("");

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void FindByModel_ShouldReturnMatchingProducts_WhenSubstringExists()
        {
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "PC101", ProductName = "Laptop A" },
        new ProductNameModel { Model = "PC102", ProductName = "Laptop B" },
        new ProductNameModel { Model = "TB200", ProductName = "Tablet X" }
    };

            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON,
                JsonSerializer.Serialize(products));

            var service = new SearchingService();
            var result = service.FindByModel("PC");

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Any(p => p.Model == "PC101"));
            Assert.That(result.Any(p => p.Model == "PC102"));
        }

        [Test]
        public void FindByModel_ShouldReturnEmpty_WhenNoMatch()
        {
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "PC101", ProductName = "Laptop A" }
    };

            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON,
                JsonSerializer.Serialize(products));

            var service = new SearchingService();
            var result = service.FindByModel("XYZ");

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindByModel_ShouldIgnoreCase_WhenSearching()
        {
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "pc101", ProductName = "Laptop A" }
    };

            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON,
                JsonSerializer.Serialize(products));

            var service = new SearchingService();
            var result = service.FindByModel("PC101");

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Model, Is.EqualTo("pc101"));
        }
        [Test]
        public void FindByProductName_ShouldReturnAll_WhenInputIsEmpty()
        {
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "PC101", ProductName = "Laptop A" },
        new ProductNameModel { Model = "PC102", ProductName = "Laptop B" }
    };

            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON,
                JsonSerializer.Serialize(products));

            var service = new SearchingService();
            var result = service.FindByProductName("");

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void FindByProductName_ShouldReturnMatchingProducts_WhenSubstringExists()
        {
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "PC101", ProductName = "Laptop A" },
        new ProductNameModel { Model = "PC102", ProductName = "Laptop B" },
        new ProductNameModel { Model = "TB200", ProductName = "Tablet X" }
    };

            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON,
                JsonSerializer.Serialize(products));

            var service = new SearchingService();
            var result = service.FindByProductName("Laptop");

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Any(p => p.ProductName == "Laptop A"));
            Assert.That(result.Any(p => p.ProductName == "Laptop B"));
        }

        [Test]
        public void FindByProductName_ShouldReturnEmpty_WhenNoMatch()
        {
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "PC101", ProductName = "Laptop A" }
    };

            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON,
                JsonSerializer.Serialize(products));

            var service = new SearchingService();
            var result = service.FindByProductName("Phone");

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindByProductName_ShouldIgnoreCase_WhenSearching()
        {
            var products = new List<ProductNameModel>
    {
        new ProductNameModel { Model = "PC101", ProductName = "laptop a" }
    };

            File.WriteAllText(PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON,
                JsonSerializer.Serialize(products));

            var service = new SearchingService();
            var result = service.FindByProductName("Laptop A");

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].ProductName, Is.EqualTo("laptop a"));
        }



    }
}
