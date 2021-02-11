// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Options;
// using Microsoft.OpenApi.Models;
// using Swashbuckle.AspNetCore.SwaggerGen;
//
// namespace CleanArchitecture.Stsutsul.Api
// {
//     public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
//     {
//         private readonly IApiVersionDescriptionProvider _provider;
//
//         /// <summary>
//         /// ctor
//         /// </summary>
//         /// <param name="provider">IApiVersionDescriptionProvider</param>
//         public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
//         {
//             _provider = provider;
//         }
//
//         /// <inheritdoc />
//         public void Configure(SwaggerGenOptions options)
//         {
//             foreach (var description in _provider.ApiVersionDescriptions)
//             {
//                 options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
//             }
//         }
//
//         private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
//         {
//             var info = new OpenApiInfo
//             {
//                 Version = description.ApiVersion.ToString(),
//                 Title = "CandleStick",
//                 Description = "Сервис для работы со свечами"
//             };
//
//             if (description.IsDeprecated)
//             {
//                 info.Description += " This API version has been deprecated.";
//             }
//
//             return info;
//         }
//     }
// }