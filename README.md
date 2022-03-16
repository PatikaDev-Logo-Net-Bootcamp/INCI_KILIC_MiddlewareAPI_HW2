# INCI_KILIC_MiddlewareAPI_HW2

Header'a parametre eklerken alınan hata aşağıdaki referans yardımı ile düzeltildi.

https://stackoverflow.com/questions/41493130/web-api-how-to-add-a-header-parameter-for-all-api-in-swagger

Endpointlerden biri Samet Hoca'nın derste bahsetmiş olduğu anotasyonda belirtilen IgnoreApi = true ile yapıldı. 

~/Controllers/HomeController/HomeController.cs 32. satır ----> [ApiExplorerSettings(IgnoreApi = true)]


Diğer Referanslar


1. https://www.thecodebuzz.com/add-custom-header-parameter-net-core-api-swagger/

2. https://www.infoworld.com/article/3617984/how-to-read-request-headers-in-aspnet-core-5-mvc.html

3. https://www.thecodebuzz.com/get-custom-header-value-net-core-web-api/

4. https://www.codingame.com/playgrounds/5110/version-class-in-c
