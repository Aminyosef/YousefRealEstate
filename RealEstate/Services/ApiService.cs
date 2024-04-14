using System.Text;
namespace RealEstate.Services;
public static class ApiService
{
    public static readonly HttpClient Client = new();
    public const string ApiUrl = "http://amingomaa-001-site8.itempurl.com/";
    public static async Task<bool> RegisterUser(string name, string email, string password, string phone)
    {
        Register register = new()
        {
            Name = name,
            Email = email,
            Password = password,
            Phone = phone
        };
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(register);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(ApiUrl + "api/users/register", content);
        return response.IsSuccessStatusCode;
    }
    public static async Task<bool> Login(string email, string password)
    {
        var login = new Login()
        {
            Email = email,
            Password = password
        };
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(login);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(ApiUrl + "api/users/login", content);
        if (!response.IsSuccessStatusCode) return false;
        var jsonResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Token>(jsonResult);
        Preferences.Set("access_token", result.AccessToken);
        Preferences.Set("userid", result.UserId);
        Preferences.Set("user_name", result.UserName);
        return true;
    }
    public static async Task<List<Category>> GetCategories()
    {
        Client.DefaultRequestHeaders.Authorization = new("bearer", Preferences.Get("access_token", string.Empty));
        var response = await Client.GetStringAsync(ApiUrl + "api/categories");
        return JsonConvert.DeserializeObject<List<Category>>(response);
    }
    public static async Task<List<TrendingProperty>> GetTrendingProperties()
    {
        Client.DefaultRequestHeaders.Authorization = new("bearer", Preferences.Get("access_token", string.Empty));
        var response = await Client.GetStringAsync(ApiUrl + "api/properties/trendingproperties");
        return JsonConvert.DeserializeObject<List<TrendingProperty>>(response);
    }
    public static async Task<List<SearchProperty>> FindProperties(string address)
    {
        Client.DefaultRequestHeaders.Authorization = new("bearer", Preferences.Get("access_token", string.Empty));
        var response = await Client.GetStringAsync(ApiUrl + "api/properties/searchproperties?address=" + address);
        return JsonConvert.DeserializeObject<List<SearchProperty>>(response);
    }
    public static async Task<List<PropertyByCategory>> GetPropertyByCategory(int categoryId)
    {
        Client.DefaultRequestHeaders.Authorization = new("bearer", Preferences.Get("access_token", string.Empty));
        var response = await Client.GetStringAsync(ApiUrl + "api/properties/propertyList?categoryId=" + categoryId);
        return JsonConvert.DeserializeObject<List<PropertyByCategory>>(response);
    }
    public static async Task<PropertyDetail> GetPropertyDetail(int propertyId)
    {
        Client.DefaultRequestHeaders.Authorization = new("bearer", Preferences.Get("access_token", string.Empty));
        var response = await Client.GetStringAsync(ApiUrl + "api/properties/propertydetail?id=" + propertyId);
        return JsonConvert.DeserializeObject<PropertyDetail>(response);
    }
    public static async Task<List<BookmarkList>> GetBookmarkList()
    {
        Client.DefaultRequestHeaders.Authorization = new("bearer", Preferences.Get("access_token", string.Empty));
        var response = await Client.GetStringAsync(ApiUrl + "api/bookmarks");
        return JsonConvert.DeserializeObject<List<BookmarkList>>(response);
    }
    public static async Task<bool> DeleteBookmark(int bookmarkId)
    {
        Client.DefaultRequestHeaders.Authorization = new("bearer", Preferences.Get("access_token", string.Empty));
        var response = await Client.DeleteAsync(ApiUrl + "api/bookmarks/" + bookmarkId);
        return response.IsSuccessStatusCode;
    }
    public static async Task<bool> AddBookmark(AddBookmark addBookmark)
    {
        var json = JsonConvert.SerializeObject(addBookmark);
        Client.DefaultRequestHeaders.Authorization = new("bearer", Preferences.Get("access_token", string.Empty));
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(ApiUrl + "api/bookmarks", content);
        return response.IsSuccessStatusCode;
    }
}