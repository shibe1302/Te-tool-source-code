using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TE_TOOL.CONFIG;
using TE_TOOL.Models;

namespace TE_TOOL.Services
{
    public class SearchingService: ISearchingService
    {
        private readonly string _filePath;

        public SearchingService()
        {
            _filePath = PATH_FILE_CONSTANT.PATH_PRODUCT_NAME_JSON;
            InitializeFile();
        }

        /// <summary>
        /// Khởi tạo file JSON nếu chưa tồn tại
        /// </summary>
        private void InitializeFile()
        {
            if (!File.Exists(_filePath))
            {
                var emptyList = new List<ProductNameModel>();
                WriteToFile(emptyList);
            }
        }

        /// <summary>
        /// Load dữ liệu từ file CSV/TXT và ghi vào file JSON
        /// </summary>
        public void LoadFromCsvOrTxt(string inputFilePath)
        {
            try
            {
                var products = new List<ProductNameModel>();

                foreach (var line in File.ReadAllLines(inputFilePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(',');

                    if (parts.Length >= 2)
                    {
                        var model = parts[0].Trim();
                        var productName = parts[1].Trim();

                        products.Add(new ProductNameModel
                        {
                            Model = model,
                            ProductName = productName
                        });
                    }
                }

                WriteToFile(products);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Lỗi khi load dữ liệu từ file CSV/TXT: {ex.Message}", ex);
            }
        }

        /// <summary> /// Lấy toàn bộ dữ liệu sản phẩm từ file JSON /// </summary> 
        /// 
        public List<ProductNameModel> GetAllProducts()
        { return ReadFromFile(); }

        /// <summary>
        /// Đọc danh sách sản phẩm từ file JSON
        /// </summary>
        public List<ProductNameModel> ReadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<ProductNameModel>();
                }

                string jsonContent = File.ReadAllText(_filePath);

                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    return new List<ProductNameModel>();
                }

                var products = JsonSerializer.Deserialize<List<ProductNameModel>>(jsonContent);
                return products ?? new List<ProductNameModel>();
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Lỗi khi đọc file JSON: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Lỗi không xác định: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Ghi danh sách sản phẩm vào file JSON
        /// </summary>
        public void WriteToFile(List<ProductNameModel> products)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string jsonContent = JsonSerializer.Serialize(products, options);
                File.WriteAllText(_filePath, jsonContent);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Lỗi khi ghi file JSON: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thêm sản phẩm mới
        /// </summary>
        public void AddProduct(ProductNameModel product)
        {
            var products = ReadFromFile();
            products.Add(product);
            WriteToFile(products);
        }

        /// <summary>
        /// Tìm sản phẩm theo Model
        /// </summary>
        public List<ProductNameModel> FindByModel(string model)
        {
            var products = ReadFromFile();

            if (string.IsNullOrEmpty(model))
                return products;

            return products
                .Where(p => !string.IsNullOrEmpty(p.Model) &&
                            p.Model.Contains(model, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<ProductNameModel> FindByProductName(string productName)
        {
            var products = ReadFromFile();

            if (string.IsNullOrEmpty(productName))
                return products;

            return products
                .Where(p => !string.IsNullOrEmpty(p.ProductName) &&
                            p.ProductName.Contains(productName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }


        /// <summary>
        /// Xóa file JSON (hữu ích cho testing)
        /// </summary>
        public void DeleteFile()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
    }
}
