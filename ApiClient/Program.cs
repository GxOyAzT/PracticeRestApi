using AllBackgroundStuff;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

HttpClient httpClient = new HttpClient();

httpClient.DefaultRequestHeaders.Add("api-version", "3.0");

httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVXNlcjEiLCJqdGkiOiI3Yzc2MmM2NC0xMTJhLTQzYzgtYWJjOC04MjQwNTMwNzdhZTUiLCJleHAiOjE2MTI3MDQ5ODYsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjE5NTUiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.YnTm7Zu1CRrUJc7IZOhupnPYpUi7v09NBAxgl-y_PcQ");

var result = await httpClient.GetAsync("https://localhost:5001/api/ModelA/");

Console.WriteLine();

// --------------------------------------------------------------------------------------------


//HttpClient httpClient = new HttpClient();

//ModelAUpdateDTO modelACreateDTO = new()
//{
//    PropInt = 100,
//    PropString = "asia@gmail.com",
//    PropGuid = Guid.NewGuid(),
//    PropDouble = 2.99F,
//    PropModelEnum = ModelEnum.EnumProp2
//};

//Console.WriteLine(nameof(ModelA));

//var convertedToJson = JsonConvert.SerializeObject(modelACreateDTO);

//var content = new StringContent(convertedToJson.ToString(), Encoding.UTF8, "application/json");

//var result = await httpClient.PutAsync("https://localhost:5001/api/ModelA/100", content);


// --------------------------------------------------------------------------------------------


//HttpClient httpClient = new HttpClient();

//PatchJson patchJson = new PatchJson(PatchOperation.add, nameof(ModelA.PropInt), 20);

//PatchJsonList patchJsonList = new(new List<PatchJson>() { patchJson });

//string str = patchJsonList.SerializeObjectToJsonFormat();

//Console.WriteLine(str);

//var content = new StringContent(str, Encoding.UTF8, "application/json");

//var result = await httpClient.PatchAsync("https://localhost:5001/api/ModelA/50", content);


// --------------------------------------------------------------------------------------------


//HttpClient httpClient = new HttpClient();

//PatchJson patchJson = new PatchJson(PatchOperation.add, nameof(ModelA.PropInt), 20);

//PatchJsonList patchJsonList = new(new List<PatchJson>() { patchJson });

//string str = patchJsonList.SerializeObjectToJsonFormat();

//Console.WriteLine(str);

//var content = new StringContent(str, Encoding.UTF8, "application/json");

//var result = await httpClient.PatchAsync("https://localhost:5001/api/ModelA/50", content);


// --------------------------------------------------------------------------------------------


//HttpClient httpClient = new HttpClient();

//LoginDTO loginDTO = new LoginDTO()
//{
//    Username = "User1",
//    Password = "Password@1"
//};

//var content = new StringContent(JsonConvert.SerializeObject(loginDTO).ToString(), Encoding.UTF8, "application/json");

//var result = await httpClient.PostAsync("https://localhost:5001/api/authenticate/login", content);

//var TokenDTO = JsonConvert.DeserializeObject<TokenDto>(result.Content.ReadAsStringAsync().Result);

//Console.WriteLine();