🚗 Car API

Bu proje, in-memory veri yapısını kullanarak temel bir Car API sağlamaktadır. API, arabaların CRUD işlemlerini gerçekleştirmeye olanak tanır.

📌 Özellikler

Araba Yönetimi

Yeni bir araba ekleme

Var olan arabaları listeleme

ID'ye göre araba detaylarını görüntüleme

Mevcut bir arabayı güncelleme

Arabayı silme

🛠 Kullanılan Teknolojiler

.NET 8 

ASP.NET Web API

FluentValidation 

📂 Proje Yapısı

Controllers/ → API Controller'ları

Models/ → Car modeli

Validators/ → FluentValidation kuralları (kullanılıyorsa)

🚀 Kurulum ve Çalıştırma

Projeyi klonlayın:

git clone https://github.com/kullanici-adin/CarAPI.git
cd CarAPI

Bağımlılıkları yükleyin:

dotnet restore

Projeyi çalıştırın:

dotnet run

API'yi test edin:

GET /api/cars → Tüm arabaları listeler.

POST /api/cars → Yeni araba ekler.

PATCH /api/cars/{id} → Belirtilen ID'ye sahip arabanın fiyatını günceller.

GET /api/cars/{id} → Belirtilen ID'ye sahip arabayı döndürür.

PUT /api/cars/{id} → Belirtilen ID'deki arabayı günceller.

DELETE /api/cars/{id} → Arabayı siler.

📖 Örnek API Kullanımı

Yeni Araba Ekleme:

{
  "brand": "Toyota",
  "model": "Corolla",
  "year": 2017,
  "price": 800000
}

🛡 Hata Yönetimi

API, standart HTTP hata kodları döndürmektedir:

200 OK → Başarılı istek

201 Created → Yeni kayıt oluşturuldu

400 Bad Request → Geçersiz veri

404 Not Found → Kayıt bulunamadı
