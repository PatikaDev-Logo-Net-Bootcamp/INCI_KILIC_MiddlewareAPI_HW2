# INCI_KILIC_MiddlewareAPI_HW2

Header'a parametre eklerken alınan hata aşağıdaki referans yardımı ile düzeltildi.

https://stackoverflow.com/questions/41493130/web-api-how-to-add-a-header-parameter-for-all-api-in-swagger

Endpointlerden biri Samet Hoca'nın derste bahsetmiş olduğu anotasyonda belirtilen IgnoreApi = true ile yapıldı. 

/Controllers/HomeController/HomeController.cs 32. satır ----> [ApiExplorerSettings(IgnoreApi = true)]

