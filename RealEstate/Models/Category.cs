namespace RealEstate.Models;
public sealed class Category
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("imageUrl")]
    public string ImageUrl { get; set; }
    public string FullImageUrl => ApiService.ApiUrl + ImageUrl;
    [JsonProperty("properties")]
    public object Properties { get; set; }
}