using ConcentraVHM;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ConcentraVHMContext>(x => x.UseSqlServer("server=localhost;database=concentraVhm;user=sa;password=reallyStrongPwd123"));

//builder.Services.AddDataServicesRegistration(app.Configuration);

var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

app.Run();

