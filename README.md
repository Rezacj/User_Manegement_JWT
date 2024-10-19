در این پروژه روی سیستمی کارشده که کاربران بعد از ورود یک توکن براشون ساخته بشه تا امنیت در بخش api هامون برقرار بشه تا اگه کسی به غیر از کاربر ها خواستن اون api رو فراخوانی کنن نتونن

## امکانات
- احراز هویت با **توکن JWT**
- حفاظت از مسیرها با `[Authorize]`
- پشتیبانی از **Authorization** بر اساس نقش‌ها
- استفاده از **Entity Framework Core** برای دیتابیس



  ## تکنولوژی‌های استفاده‌شده
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT Authentication


## روش اجرای api در javascript

- const token = localStorage.getItem('jwtToken'); // توکن رو بعد از ورود ذخیره میکنیم 

- fetch('https://localhost:5001/api/weather/getweather', {
- method: 'GET',
- headers: {
-   'Authorization': `Bearer ${token}` // ارسال توکن در هدر 
-  }
- })
- .then(response => {
-   if (response.status === 401) {
-      throw new Error('Unauthorized - Invalid token');
-   }
-    return response.json();
-  })
-  .then(data => console.log('Weather Data:', data))
-  .catch(error => console.error('Error:', error));
