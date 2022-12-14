# Topic: Web Authentication & Authorisation.

## Course: Cryptography & Security

## Author: Gherman Adrian

# Theory

While often used interchangeably, authentication and authorization represent fundamentally different functions.,
authentication is the process of verifying who someone is, whereas authorization is the process of verifying what
specific applications, files, and data a user has access to. The situation is like that of an airline that needs to
determine which people can come on board. The first step is to confirm the identity of a passenger to make sure they are
who they say they are. Once a passenger’s identity has been determined, the second step is verifying any special
services the passenger has access to. What we need to understand is that Authentication verifies who the user is, while
authorization determines what resources a user can access. Authentication works through passwords, one-time pins,
biometric information, and other information provided or entered by the user but authorization works through settings
that are implemented and maintained by the organization.

# Objectives:

1. Take what you have at the moment from previous laboratory works and put it in a web service / serveral web services.
2. Your services should have implemented basic authentication and MFA (the authentication factors of your choice).
3. Your web app needs to simulate user authorization and the way you authorise user is also a choice that needs to be
   done by you.
   As services that your application could provide, you could use the classical ciphers. Basically the user would like
   to get access and use the classical ciphers, but they need to authenticate and be authorized.

# Implementation description

### Application run

#Implementation steps
As soon as we ran the application, we can see that we are landed on log in page. This is because our content is hidden
for unauthorized persons. So in order to have access to the ciphers, we have to firstly to pass Authentication step.

### Register and login

![alt text](https://github.com/[adrian28102001]/[Cryptography-and-Security]/blob/[main]/register.png?raw=true)


After we did register, and passing password requirements for lenght, having capitals letters, we can now login.
In order to login we need to pass the same username and password as previously used to register.

As soon as we press login, if everything matches, we will see the 2FA, in this case connected with google authentication
app from my phone. Unfortunately, google's app privacy does not allow me to do a screenshot, so you have to believe me.
![alt text](https://github.com/[adrian28102001]/[Cryptography-and-Security]/blob/[main]/2FA.png?raw=true)

As I said, we need to provide the code from the app, which changes every 30 seconds, for security reasons.

As you can see, we have passed both authentication and authorization step. Note that the url is the same as
initial, localhost:port, but now we see a different content. Because initially we were not authenticated, we were
redirected
to login page.

![alt text](https://github.com/[adrian28102001]/[Cryptography-and-Security]/blob/[main]/home.png?raw=true)

We are restricted by the [Authorize] annotation which allows entering in the method only being logged in.

````csharp
   [Authorize]
    public IActionResult Index()
    {
        return View();
    }
````

Same, having access to the Cipher view

````csharp
[Authorize]
    [HttpPost]
    public IActionResult CaesarCipher(string textToEncrypt, int key)
    {
        var model = new CaesarCipher();
        var caesarEncrypt = _caesarCipher.Encrypt(textToEncrypt, key);
        var caesarDecrypt = _caesarCipher.Decrypt(caesarEncrypt, key);
        
        model.Encrypted = caesarEncrypt;
        model.Decrypted = caesarDecrypt;
        
        return View(model);
    }
````

In order not to complete life, I did choose for this example to use the Caesar cipher I did in the first lab.
Note: all of the other ciphers can be easily be added ad this one in the example.

We do have a form, with 2 fields and a button and expects as input a string and an it, which will be used
to Caesar algorithm

![alt text](https://github.com/[adrian28102001]/[Cryptography-and-Security]/blob/[main]/CaesarDemo.png?raw=true)


````csharp

<div class="text-center">
    @using (Html.BeginForm("CaesarCipher", "Home", FormMethod.Post, new {enctype = "multipart/form-data"}))
    {
        <div>
            <label for="Text">Text to encrypt:</label>
            <input type="text" name="textToEncrypt" value="textToEncrypt"/>
            <label for="Text">Key to encrypt:</label>
            <input type="number" name="key" value="key"/>
            <button type="submit" name="save" value="save" class="button">Caesar encryption</button>
        </div>
    }
</div>
````

As soon as we provide necessary input values and do submit, we are redirected to another page where the result is

![alt text](https://github.com/[adrian28102001]/[Cryptography-and-Security]/blob/[main]/CaesarResult.png?raw=true)

As we can see, the result is displayed here. As I said, we can have the list of all the ciphers from this year,
so the user can protect his text and encrypt it on our website.

Authorization and authentication were done with the help of dotnet 6, which allows you to have them at the moment of
generation of the project.

# Conclusion

In this laboratory work I did learn how to use 2fa, how to restrict content for users which are not meant to see certain
information.
Authentication and Authorization is very important for securing resources and limiting access in the whole IT.
