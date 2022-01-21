# ReCapProject-Back-End

# Rent A Car Project

This project is an online car rental project.
(Bu proje bir online araç kiralama projesidir.)

 ReCapProject-Back-End; Kurumsal, Katmanlı Mimari yapısı kullanılarak *SOLID* kuralları dahilinde oluşturulmuş, *C#* dili ile yazılmıştır.<br/>
Bu proje bir online araç kiralama projesidir.

## Katmanlar

- **Business** : Projemizin iş katmanıdır. Gerekli iş kuralları; Veri kontrolleri, Validasyonlar, IoC Container'lar ve yetki kontrolleri için yazılmış katmandır.
- **Core** : Projenin çekirdek katmanı olup içerisinde evrensel operasyonlar barındırmaktadır..
- **DataAccess** : Projede veritabanımız ile bağlantımızı kurduğumuz katmanımızdır.
- **Entities** : Projede veritabanındaki tablolarımızın projemizde nesne olarak kullanılması için oluşturulmuş olup, içerisinde DTO nesneleri de yer almaktadır.
- **WebAPI** : Projenin Restful API katmanıdır. İçerisinde kullanılan metodlar; Get, Post, Put, Delete metodlarıdır.

## Kullanılan Teknolojiler

- MsSql
- .Net Core 3.1
- EntityFramework
- Restful API
   - File upload
- Result Türleri
- Interceptor
- Autofac (IOC)
- Autofac Dependency Resolvers
  - AOP, (Aspect Oriented Programming)
    - Caching
    - Performance
    - Transaction
- Validation
- Fluent Validation
- Cache yönetimi
- JWT Authentication
- Cross Cutting Concerns
  - Caching
  - Validation
- Extensions
  - Claim
    - Claim Principal
  - Error Handling
    - Error Details
    - Validation Error Details
