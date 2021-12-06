using AspNetCoreHero.ToastNotification;
using EmailServices;
using EShop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace EShop
{
    //ádasd
    //ditme
    //testpushádasdsadasd
    public class Startup
    {
        //asdasda
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region //Cookies
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".EShop";
                options.IdleTimeout = TimeSpan.FromSeconds(300);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(p =>
                {
                    p.LoginPath = "/login.html";
                    p.LoginPath = "/Admin/Login/Index";
                    p.AccessDeniedPath = "/";
                });
            #endregion

            #region //services GG
            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    // Đọc thông tin Authentication:Google từ appsettings.json
                    IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");

                    // Thiết lập ClientID và ClientSecret để truy cập API google
                    googleOptions.ClientId = googleAuthNSection["ClientId"];
                    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                    // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
                    googleOptions.CallbackPath = "/dang-nhap-tu-google";

                });
            #endregion

            services.AddDbContext<EcommerceVer2Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EShopDb")));
            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddSessionStateTempDataProvider();
            services.AddNotyf(config => { config.DurationInSeconds = 5; config.IsDismissable = false; config.Position = NotyfPosition.TopRight; });

            // MailServer
            var emailconfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailconfig);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapGet("/TestSendMailServices", async (context) => {
                //    var sendmailservices = context.RequestServices.GetService<SendMailServices>();
                //    var mailcontent = new MailContent();
                //    mailcontent.To = "Laihuyha@gmail.com";
                //    mailcontent.SubJect = "Test";
                //    mailcontent.Body = "<h1>Test<h1> test";
                //    var kq = await sendmailservices.SendMail(mailcontent);
                //    await context.Response.WriteAsync(kq);
                //});
            });
        }
    }
}
