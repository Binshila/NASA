namespace NASAWebApp.Models.AssetDetails
{
    public class NasaAsset
    {
        public NasaAssetCollection Collection { get; set; }
    }

    public class NasaAssetCollection
    {
        public string Version { get; set; }
        public string Href { get; set; }
        public List<NasaAssetItem> Items { get; set; }
    }

    public class NasaAssetItem
    {
        public string Href { get; set; }
    }


}
