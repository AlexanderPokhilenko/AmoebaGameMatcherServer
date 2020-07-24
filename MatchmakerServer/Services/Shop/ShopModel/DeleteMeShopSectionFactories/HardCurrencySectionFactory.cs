using DataLayer.Tables;
using NetworkLibrary.NetworkLibrary.Http;

namespace AmoebaGameMatcherServer.Services.Shop.ShopModel.DeleteMeShopSectionFactories
{
    /// <summary>
    /// Создаёт данные для раздела хард валюты в магазне.
    /// </summary>
    public class HardCurrencySectionFactory
    {
        public SectionModel Create()
        {
            SectionModel sectionModel = new SectionModel
            {
                NeedFooterPointer = true,
                HeaderName = "GEM PACKS",
                SectionTypeEnum = SectionTypeEnum.HardCurrency
            };
            sectionModel.UiItems = new ProductModel[2][];
            
            //верхняя строка
            sectionModel.UiItems[0] = new[]
            {
                new ProductModel
                {
                    TransactionType = TransactionTypeEnum.HardCurrency,
                    CurrencyTypeEnum = CurrencyTypeEnum.RealCurrency,
                    ImagePreviewPath = "diamonds5",
                    ForeignServiceProduct = new ForeignServiceProduct
                    {
                        ProductGoogleId = ForeignServiceProducts.HardCurrency30,
                        Consumable = true
                    },
                    Name = "30",
                    ShopItemSize = ProductSizeEnum.Small,
                    Id = 3
                }, 
                new ProductModel
                {
                    TransactionType = TransactionTypeEnum.HardCurrency,
                    CurrencyTypeEnum = CurrencyTypeEnum.RealCurrency,
                    ImagePreviewPath = "diamonds10",
                    ForeignServiceProduct = new ForeignServiceProduct
                    {
                        ProductGoogleId = ForeignServiceProducts.HardCurrency80,
                        Consumable = true
                    },
                    Name = "80",
                    ShopItemSize = ProductSizeEnum.Small,
                    Id = 4
                },
                new ProductModel
                {
                    TransactionType = TransactionTypeEnum.HardCurrency,
                    CurrencyTypeEnum = CurrencyTypeEnum.RealCurrency,
                    ImagePreviewPath = "diamonds15",
                    ForeignServiceProduct = new ForeignServiceProduct
                    {
                        ProductGoogleId = ForeignServiceProducts.HardCurrency170,
                        Consumable = true
                    },
                    Name = "170",
                    ShopItemSize = ProductSizeEnum.Small,
                    Id = 5
                }
            }; 
            
            //нижняя строка
            sectionModel.UiItems[1] = new[]
            {
                new ProductModel
                {
                    TransactionType = TransactionTypeEnum.HardCurrency,
                    CurrencyTypeEnum = CurrencyTypeEnum.RealCurrency,
                    ImagePreviewPath = "diamonds20",
                    ForeignServiceProduct = new ForeignServiceProduct
                    {
                        ProductGoogleId = ForeignServiceProducts.HardCurrency360,
                        Consumable = true
                    },
                    Name = "360",
                    ShopItemSize = ProductSizeEnum.Small,
                    Id = 5
                },
                new ProductModel
                {
                    TransactionType = TransactionTypeEnum.HardCurrency,
                    CurrencyTypeEnum = CurrencyTypeEnum.RealCurrency,
                    ImagePreviewPath = "diamonds40",
                    ForeignServiceProduct = new ForeignServiceProduct
                    {
                        ProductGoogleId = ForeignServiceProducts.HardCurrency950,
                        Consumable = true
                    },
                    Name = "950",
                    ShopItemSize = ProductSizeEnum.Small,
                    Id = 6
                },
                new ProductModel
                {
                    TransactionType = TransactionTypeEnum.HardCurrency,
                    CurrencyTypeEnum = CurrencyTypeEnum.RealCurrency,
                    ImagePreviewPath = "diamonds80",
                    ForeignServiceProduct = new ForeignServiceProduct
                    {
                        ProductGoogleId = ForeignServiceProducts.HardCurrency2000,
                        Consumable = true
                    },
                    Name = "2000",
                    ShopItemSize = ProductSizeEnum.Small,
                    Id = 7
                }
            };
            
            return sectionModel;
        }
    }
}