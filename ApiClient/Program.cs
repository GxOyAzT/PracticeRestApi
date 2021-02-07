using AllBackgroundStuff;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;



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