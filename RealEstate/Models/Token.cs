﻿namespace RealEstate.Models;
public sealed class Token
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
    [JsonProperty("token_type")]
    public string TokenType { get; set; }
    [JsonProperty("user_id")]
    public string UserId { get; set; }
    [JsonProperty("user_name")]
    public string UserName { get; set; }
}