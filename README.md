# JwtTools

<h1>Jwt加密解密工具dll</h1>
```csharp
Encode:
	Dictionary<string,object> payload,string secret
    //payload：用户, secret:定义的密钥
Decode:
	string token, string secret
    //token需要的解码字符串，secret：同上
```

Webapi中使用