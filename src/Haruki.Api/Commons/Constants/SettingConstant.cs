namespace Haruki.Api.Commons.Constants;

public static class SettingConstant
{
    #region constant
    private const string Development = "Development";
    #endregion
    
    #region General
    public static string WebUrl { get; set; }

    public static string WebRouteConfirm { get; set; }
    
    public static string WebRouteOtp { get; set; }
    
    public static string WebRouteExternal { get; set; }
    
    public static string WebRouteReset { get; set; }

    public static string DefaultConnectionString { get; set; }
    
    public static string HangfireConnectionString { get; set; }
    
    public static string Cors { get; set; }
    
    public static string Identity { get; set; }
    
    #endregion
    
    #region Jwt
    public static string JwtIssuer { get; set; }
    
    public static string JwtAudience { get; set; }
    
    public static string JwtSecret { get; set; }
    
    public static int JwtExpireIn { get; set; }
    #endregion

    #region Hangfire

    public static string HangfireUserName { get; set; }
    
    public static string HangfirePassword { get; set; }

    #endregion
    
    #region oAuth
    public static string GoogleAuthKey { get; set; }
    public static string GoogleAuthSecret { get; set; }
    #endregion
    
    #region reCatpcha
    public static string GoogleCaptchaUrl { get; set; }
    public static string GoogleCaptchaKey { get; set; }
    public static string GoogleCaptchaSecret { get; set; }
    #endregion

    #region SendInBlue
    public static string SendInBlueApiKey { get; set; }
    #endregion
    
    #region Firebase
    public static string FirebaseStorageApiKey { get; set; }
    public static string FirebaseStorageBucket { get; set; }
    public static string FirebaseStorageUsr { get; set; }
    public static string FirebaseStoragePwd { get; set; }
    #endregion

    #region Templates
    public static string TemplateActivation { get; set; }
    public static string TemplateWelcome { get; set; }
    public static string TemplateReset { get; set; }
    public static string TemplatePassword { get; set; }
    public static string TemplateOtp { get; set; }
    public static string TemplateLocked { get; set; }
    #endregion

    public static void LoadSetting(IConfiguration configuration)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        Console.WriteLine($"Environment : {environment}");

        if (environment is Development)
        {
            JwtIssuer = configuration.GetSection("Jwt:Issuer").Value;
            JwtAudience = configuration.GetSection("Jwt:Audience").Value;
            JwtSecret = configuration.GetSection("Jwt:Secret").Value;
            JwtExpireIn = Convert.ToInt32(configuration.GetSection("Jwt:ExpiresIn").Value);
            WebUrl = configuration.GetSection("AppSettings:Web:Url").Value;
            WebRouteConfirm = configuration.GetSection("AppSettings:Web:Routes:AccountConfirm").Value;
            WebRouteOtp = configuration.GetSection("AppSettings:Web:Routes:AccountOtp").Value;
            WebRouteExternal = configuration.GetSection("AppSettings:Web:Routes:AccountExternal").Value;
            WebRouteReset = configuration.GetSection("AppSettings:Web:Routes:AccountReset").Value;
            DefaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            HangfireConnectionString = configuration.GetConnectionString("HangfireConnection");
            HangfireUserName = configuration.GetSection("Hangfire:Credentials:UserName").Value;
            HangfirePassword = configuration.GetSection("Hangfire:Credentials:Password").Value;
            Cors = configuration.GetSection("AppSettings:Cors").Value;
            Identity = configuration.GetSection("AppSettings:Identity").Value;
            SendInBlueApiKey = configuration.GetSection("SendInBlue:ApiKey").Value;
            FirebaseStorageApiKey = configuration.GetSection("Firebase:Storage:ApiKey").Value;
            FirebaseStorageBucket = configuration.GetSection("Firebase:Storage:Bucket").Value;
            FirebaseStorageUsr = configuration.GetSection("Firebase:Storage:Usr").Value;
            FirebaseStoragePwd = configuration.GetSection("Firebase:Storage:Pwd").Value;
            TemplateActivation = configuration.GetSection("Templates:Activation").Value;
            TemplateWelcome = configuration.GetSection("Templates:Welcome").Value;
            TemplateReset = configuration.GetSection("Templates:Reset").Value;
            TemplatePassword = configuration.GetSection("Templates:Password").Value;
            TemplateOtp = configuration.GetSection("Templates:Otp").Value;
            TemplateLocked = configuration.GetSection("Templates:Locked").Value;
            GoogleCaptchaUrl = configuration.GetSection("GoogleCaptcha:Endpoint").Value;
            GoogleCaptchaKey = configuration.GetSection("GoogleCaptcha:Key").Value;
            GoogleCaptchaSecret = configuration.GetSection("GoogleCaptcha:Secret").Value;
            GoogleAuthKey = configuration.GetSection("oAuth:Google:Key").Value;
            GoogleAuthSecret = configuration.GetSection("oAuth:Google:Secret").Value;
        }
        else
        {
            JwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            JwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            JwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
            JwtExpireIn = Convert.ToInt32(Environment.GetEnvironmentVariable("JWT_EXPIRE"));
            WebUrl = Environment.GetEnvironmentVariable("APP_SETTINGS_WEB_URL");
            WebRouteConfirm = Environment.GetEnvironmentVariable("APP_SETTINGS_WEB_ROUTE_CONFIRM");
            WebRouteOtp = Environment.GetEnvironmentVariable("APP_SETTINGS_WEB_ROUTE_OTP");
            WebRouteExternal = Environment.GetEnvironmentVariable("APP_SETTINGS_WEB_ROUTE_EXTERNAL");
            WebRouteReset = Environment.GetEnvironmentVariable("APP_SETTINGS_WEB_ROUTE_RESET");
            DefaultConnectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");
            HangfireConnectionString = Environment.GetEnvironmentVariable("HANGFIRE_CONNECTION");
            HangfireUserName = Environment.GetEnvironmentVariable("HANGFIRE_USERNAME");
            HangfirePassword = Environment.GetEnvironmentVariable("HANGFIRE_PASSWORD");
            Cors = Environment.GetEnvironmentVariable("APP_SETTINGS_CORS");
            Identity = Environment.GetEnvironmentVariable("APP_SETTINGS_IDENTITY");
            SendInBlueApiKey = Environment.GetEnvironmentVariable("SENDINBLUE_APIKEY");
            FirebaseStorageApiKey = Environment.GetEnvironmentVariable("FI_STORAGE_APIKEY");
            FirebaseStorageBucket = Environment.GetEnvironmentVariable("FI_STORAGE_BUCKET");
            FirebaseStorageUsr = Environment.GetEnvironmentVariable("FI_STORAGE_USR");
            FirebaseStoragePwd = Environment.GetEnvironmentVariable("FI_STORAGE_PWD");
            TemplateActivation = Environment.GetEnvironmentVariable("TEMPLATE_ACTIVATION");
            TemplateWelcome = Environment.GetEnvironmentVariable("TEMPLATE_WELCOME");
            TemplateReset = Environment.GetEnvironmentVariable("TEMPLATE_RESET");
            TemplatePassword = Environment.GetEnvironmentVariable("TEMPLATE_PASSWORD");
            TemplateOtp = Environment.GetEnvironmentVariable("TEMPLATE_OTP");
            TemplateLocked = Environment.GetEnvironmentVariable("TEMPLATE_LOCKED");
            GoogleCaptchaUrl = Environment.GetEnvironmentVariable("G_CAPTCHA_ENDPOINT");
            GoogleCaptchaKey = Environment.GetEnvironmentVariable("G_CAPTCHA_KEY");
            GoogleCaptchaSecret = Environment.GetEnvironmentVariable("G_CAPTCHA_SECRET");
            GoogleAuthKey = Environment.GetEnvironmentVariable("G_OAUTH_KEY");
            GoogleAuthSecret = Environment.GetEnvironmentVariable("G_OAUTH_SECRET");
        }

        Console.WriteLine($"JwtIssuer : {JwtIssuer}");
        Console.WriteLine($"JwtAudience : {JwtAudience}");
        Console.WriteLine($"JwtSecret : {JwtSecret}");
        Console.WriteLine($"JwtExpireIn : {JwtExpireIn}");
        Console.WriteLine($"WebUrl : {WebUrl}");
        Console.WriteLine($"WebRouteConfirm : {WebRouteConfirm}");
        Console.WriteLine($"WebRouteOtp : {WebRouteOtp}");
        Console.WriteLine($"WebRouteExternal : {WebRouteExternal}");
        Console.WriteLine($"WebRouteExternal : {WebRouteReset}");
        Console.WriteLine($"DefaultConnectionString : {DefaultConnectionString}");
        Console.WriteLine($"HangfireConnectionString : {HangfireConnectionString}");
        Console.WriteLine($"HangfireUserName : {HangfireUserName}");
        Console.WriteLine($"HangfirePassword : {HangfireUserName}");
        Console.WriteLine($"Cors : {Cors}");
        Console.WriteLine($"Identity : {Identity}");
        Console.WriteLine($"SendInBlueApiKey : {SendInBlueApiKey}");
        Console.WriteLine($"FirebaseStorageApiKey : {FirebaseStorageApiKey}");
        Console.WriteLine($"FirebaseStorageBucket : {FirebaseStorageBucket}");
        Console.WriteLine($"FirebaseStorageUsr : {FirebaseStorageUsr}");
        Console.WriteLine($"FirebaseStoragePwd : {FirebaseStoragePwd}");
        Console.WriteLine($"TemplateActivation : {TemplateActivation}");
        Console.WriteLine($"TemplateWelcome : {TemplateWelcome}");
        Console.WriteLine($"TemplateReset: {TemplateReset}");
        Console.WriteLine($"TemplatePassword : {TemplatePassword}");
        Console.WriteLine($"TemplateOtp : {TemplateOtp}");
        Console.WriteLine($"TemplateLocked : {TemplateLocked}");
        Console.WriteLine($"GoogleCaptchaUrl : {GoogleCaptchaUrl}");
        Console.WriteLine($"GoogleCaptchaKey : {GoogleCaptchaKey}");
        Console.WriteLine($"GoogleCaptchaSecret : {GoogleCaptchaSecret}");
        Console.WriteLine($"GoogleAuthKey : {GoogleAuthKey}");
        Console.WriteLine($"GoogleAuthSecret : {GoogleAuthSecret}");
    }
}