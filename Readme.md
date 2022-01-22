## TAL Web API

---

You can access T.Airlines' plane inventory through this WEB API. But, you have to be admin (authorized user) to access all the features.

You can register through Swagger:
\
&nbsp;
![SwaggerUIInıtialization](https://github.com/AKBANK-Patika-FullStack-Bootcamp/ElifsuTanyeri_Homeworks/blob/master/Week5_AuthToken%26Paging/Screenshots/1normalstate.PNG)
\
\
&nbsp;
If you register successfully, you can login to your account within the same UI. Successfull login means you will have a valid token for a quite good period of time, so that you don't have to login again and again. After one last step, you are ready to access to TAL database. Please copy and paste your verified token code to Swagger's Authorize section, don't forget to add "bearer" in the beginning!
\
\
&nbsp;
![Token](https://github.com/AKBANK-Patika-FullStack-Bootcamp/ElifsuTanyeri_Homeworks/blob/master/Week5_AuthToken%26Paging/Screenshots/2LoginSuccess.PNG)
\
\
&nbsp;
After seeing the above message, you are ready to go on!
\
\
&nbsp;

![Verification](https://github.com/AKBANK-Patika-FullStack-Bootcamp/ElifsuTanyeri_Homeworks/blob/master/Week5_AuthToken%26Paging/Screenshots/3TokenSuccess.PNG)
\
\
&nbsp;
Oh, by the way, your password will be stored in the database **cyrpted**, so don't worry :)
\
\
&nbsp;
![CryptedPassword](https://github.com/AKBANK-Patika-FullStack-Bootcamp/ElifsuTanyeri_Homeworks/blob/master/Week5_AuthToken%26Paging/Screenshots/5CryptedSQL.PNG)
\
\
&nbsp;

- After authorization, you can see the full inventory by the "get" method.

- If you are searching for a specific plane's maintanance information, please try "get" method with Id. _[If you enter the number of planes you want to see in a page, you won't have to deal with lots of plane data in a single page!]_

- You can update the plane information by "put" section.

- You can add a new plane to the inventory by "post" method.

- You can delete the plane by "delete" method.
  \
  &nbsp;

---

> _Thank you for visiting us!_
