using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Notes.Identity
{
    /// <summary>
    /// Класс Configuration содержит информацию о клиентах, ресурсах и т.д.
    /// То есть, информация о клиентских приложениях которым разрешено использовать
    /// наш IdentityServer.
    /// </summary>
    public class Configuration
    {
        // ApiScope - представляет то, что клиентскому приложению можно использовать.
        // То есть, идентификатор для ресурсов. 
        // Идентификатор отправляется в процессе аутентификации или запроса токена.
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("NotesWebAPI", "Web API")
            };

        // IdentityResource - позволяет смоделировать область,
        // которая позволит клиентскому приложению просматривать подмножество утверждений о пользователе.
        // Например: Имя, Дата рождения.
        // Утверждения называют - КЛЕЙМАМИ.
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        // ApiResource - позволяет смоделировать доступ ко всему защищенному ресурсу.
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("NotesWebApi", "Web API", new[] { JwtClaimTypes.Name })
                {
                    Scopes = {"NotesWebAPI"}
                }
            };

        // Client - IdentityServer должен знать, каким клиентским приложениям позволено использовать его.
        // Клиенты - как списки приложений, которые могут использовать нашу систему.
        // Каждое клиентское приложение конфигурируется так, что ему позволено делать определенный набор вещей.
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "notes-web-api", // Это индентификатор клиента. В конфигурации клиента должен быть точно такой же.
                    ClientName = "Notes Web", // Имя клиента.
                    AllowedGrantTypes = GrantTypes.Code, // Определяет как клиент взаимодействует с сервисом токеном.
                    RequirePkce = true, // Нужен ли ключ подтверждения для Authorization Code
                    RequireClientSecret = false,
                    RedirectUris = // Набор Uri адресов, куда может происходить перенаправление после аутентификации клиентского приложения
                    {
                        "http://...//signin-oidc"
                    },
                    AllowedCorsOrigins = // Набор Uri адресов, кому можно использовать IdentityServer
                    {
                        "http://..."
                    },
                    PostLogoutRedirectUris = // Набор Uri адресов, куда может происходить перенаправление после выхода клиентского приложения
                    {
                        "http://...//signout-oidc"
                    },
                    AllowedScopes = // Области, доступные клиенту 
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "NotesWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true, // Управляет передачей токена доступа через браузер
                }
            };
    }
}
