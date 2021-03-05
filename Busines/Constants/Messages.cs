using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;

namespace Busines.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarNameInvalid = "Eklediğiniz aracın ismi minimum 2 karakter olmalıdır!";
        public static string CarDailyPrice = "Eklediğiniz aracın günlük fiyatı 0'dan büyük olmalıdır!";
        public static string MaintenanceTime = "Bakım Zamanı";
        public static string CarUpdated = "Araç Güncellendi";
        public static string CarDeleted = "Araç Silindi";
        public static string GetCarDetails = "Araçlar Listelendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string RentalAdded = "Kiralama Eklendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string RentalAddedError = "Kiralama Ekleme Hatalı";
        public static string NotAvailable = "Mevcut Değil";
        public static string RentalDeleted = "Kiralama Silindi";
        public static string RentalUpdated = "Kiralama Güncellendi";
        public static string RentalListed = "Kiralama Listelendi";
        public static string CarsListed = "Araçlar Listelendi";
        public static string CarsDescriptionListed = "Araç Özellikleri Listelendi";
        public static string ListedByColor = "Renge Göre Listelendi";
        public static string ListedByBrand = "Markaya Göre Listelendi";
        public static string CarsDetailListed = "Araç Detayları Listelendi";
        public static string ListedByCarId = "Araç Id'ye Göre Listelendi";
        public static string PasswordControl = "Oluşturmak İstediğiniz Şifreniz; En Az Bir Rakam, Bir Harf ve 8 Karakterden Oluşmalıdır!";
        public static string EmailControl = "LÜtfen Geçerli Bir Email Adresi Giriniz!";
        public static string BrandsListed = "Markalara göre Listelendi";
        public static string PriceRangeListed = "Günlük Fiyat Aralığına göre Listelendi";
        public static string ColorListed = "Renge Göre Listelendi";
        public static string ColorsListed = "Renklere göre Listelendi";
        public static string ListedByColorId = "Renk Id'ye Göre Listelendi";
        public static string ListedByBrandId = "Marka Id'ye Göre Listelendi";
        public static string CustomersListed = "Müşteriler Listelendi";
        public static string ListedByCustomerId = "Müşteriler Id'ye Göre Listelendi";
        public static string ListedByRentalId = "Kiralama Id'ye Göre Listelendi";
        public static string ListedByRentalUndelivered = "Kiralama Teslim Durumuna Göre Listelendi";
        public static string ListedByUserId = "Kullanıcı Id'ye Göre Listelendi";
        public static string NotYetSuitableforReRental = "Yeniden Kiralama için Henüz Uygun Değil";
        public static string CarCountOfCategoryError = "Bir Kategoriye En Fazla 15 Nesne Eklenebilir!";
        public static string CarNameAllreadyExists = "Aynı İsimli Araba Eklenemez!";
        public static string CarNotAdded = "Araç Eklenemedi";
        public static string CustomerLimitExiceded = "Müşteri Sayısı Aşıldı, Eklenemz!";
        public static string ImageAdded = "Resim Eklendi";
        public static string ImageDeleted = "Resim Silindi";
        public static string ImageUpdated = "Resim Güncellendi";
        public static string ImageInsertionLimitExceeded = "Resim Ekleme Sınırı Aşıldı";
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string InValidImageExtension = "Geçersiz Görüntü Dosya Uzantısı";
        public static string UserListedByMail = "Kullanıcı Mail'e Göre Listelendi";
        public static string ClaimsListed = "Kullanıcı Rolleri Listelendi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatası";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string UserRegistered = "Kullanıcı Kaydedildi";
        public static string AccessTokenCreated = "Giriş Anahtarı Oluşturuldu.";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";
    }
}
