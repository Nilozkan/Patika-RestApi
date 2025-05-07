Car API - .NET Core RESTful Service
Bu proje, .NET 8 ile geliştirilmiş basit bir RESTful Web API uygulamasıdır. API, arabaları (Car) yönetmek için temel CRUD işlemlerini sağlar. Projede SOLID prensiplerine uygun mimari ve temel .NET yetenekleri kullanılmıştır.

📚 İçerik
REST standartlarına uygun API controller yapısı

SOLID prensiplerine uygun servis katmanı

Fake servis kullanımı (veritabanı yok)

Dependency Injection

FluentValidation

Swagger dokümantasyonu

Extension method kullanımı

Global hata yakalama (exception middleware)

Logging middleware

Basit fake login ve custom authorization attribute (bonus)

🚀 Başlarken
1. Projeyi Çalıştırma
2. 
git clone https://github.com/kullaniciadi/proje-adi.git
cd proje-adi
dotnet run
3. Swagger UI'ya Erişim
Projeyi çalıştırdıktan sonra aşağıdaki URL üzerinden Swagger arayüzüne ulaşabilirsiniz:


https://localhost:{port}/swagger
🛠️ Kullanılan Teknolojiler
Teknoloji	Açıklama
.NET 8	Web API geliştirme
FluentValidation	Model doğrulama
Swagger	API dokümantasyonu
Middleware	Global hata yakalama ve loglama
Attribute	Fake kullanıcı yetkilendirme için custom attribute
SOLID	Kod organizasyonu

🔁 Endpointler
Metot	URL	Açıklama
GET	/api/car/all	Tüm arabaları getirir ([FakeAuthorize] ile korunur)
GET	/api/car/{id}	ID ile araba getirir
POST	/api/car	Yeni araba ekler
PUT	/api/car/{id}	Arabayı günceller
PATCH	/api/car/{id}	Sadece fiyat günceller
DELETE	/api/car/{id}	Arabayı siler

🔐 Fake Login Sistemi
FakeAuthorize attribute'u sadece giriş yapmış gibi davranan kullanıcılar için belirli endpointleri korur.

Gerçek kullanıcı girişi yoktur, fake olarak kontrol yapılır.

Authorization kontrolü FakeAuthorizeAttribute.cs içinde yer alır.

🧪 Validasyon Kuralları
Araba modeli (Car) FluentValidation kullanılarak şu kurallara göre doğrulanır:

Brand: boş olamaz

Model: boş olamaz

Year: 2000 ve sonrası olmalı

Color: boş olamaz

Price: 0'dan büyük olmalı

⚙️ Custom Middleware’ler
GlobalExceptionMiddleware: Tüm hataları merkezi olarak yakalar.

LogMiddleware: Gelen istekleri loglar.

📁 Katmanlar

RestApi
│
├── Controllers
│   └── CarController.cs
├── Models
│   └── Car.cs
├── Services
│   ├── ICarService.cs
│   └── FakeCarService.cs
├── Validators
│   └── CarValidator.cs
├── Middlewares
│   ├── GlobalExceptionMiddleware.cs
│   └── LogMiddleware.cs
├── Attributes
│   └── FakeAuthorizeAttribute.cs
├── Extensions
│   └── ServiceExtension.cs
└── Program.cs
✍️ Geliştirici Notları
Projede veritabanı kullanılmamıştır, tüm işlemler in-memory list üzerinden yapılmaktadır.

SOLID prensiplerine göre ICarService interface’i üzerinden servis kullanımı sağlanmıştır.

Swagger üzerinden tüm istekler kolayca test edilebilir.

