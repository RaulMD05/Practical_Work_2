
**UNIVERSIDAD FRANCISCO DE VITORIA**

**ESCUELA POLITÉCNICA SUPERIOR**

**![](data:image/png;base64...)**

**Practical Work II OOP**

Raúl Muñoz Dobón.

##

##

##

**Table of contents**

[**Introduction 2**](#_8axg9dapmv8z)

[**Description 4**](#_xqci34of90oi)

[**UML Diagram 4**](#_mzxd9owq2bi5)

[**Solution Design 5**](#_7ezn8sejfaqr)

[**Problems 9**](#_qetg7wqgt3zt)

[**Conclusions 10**](#_kl7kaw2t5wwp)

# **Introduction**

This document details the design and development of the OOP Calculator, it describes the design, challenges and the new learnings , which were developed by Raúl Muñoz.

The document is constructed in such a manner that I will extensively discuss the various challenges which I found throughout the development process of our project, the methods and functions present within C#, and Maui which were the languages I used to make this project.

I have come to believe that the project was complex, but was more or less on the same level with the content which we had covered in class. However, I have unanimously also agreed upon the conclusion that the scope of new important implementations like Maui, as it is the first time using this type of coding, combining it with C#, which was an enormous challenge to face.

Most of the conclusions and evaluations of the solutions which I came up with are the product of extensive pondering and attempts to bypass the limitations which I encountered within the framework of the project which we were given. The different uses of the files, and the abstraction used on the activity, has helped me a lot to reduce the code, and have it a bit more organized, which also makes the code easier to follow, and it simplifies much of what could have been much longer. It should also be noted that a series of assumptions have been made throughout the process of creating our methods.

Among the most notable is the fact that, we assume, that anyone making use of our code will possess the knowledge that this is a simple app, but it is not explained, though it is really intuitive to use. The use of other systems, such as relative paths, has also been an important part of the work, which makes it also easier for the person who uses the code, as he doesn’t have to insert the absolute path himself.

# **Description**

The Converter calculator was created with the intention of having any conversion possible, convincing it with maui. It also has a Login with its register page, and Forgot Password, with also a User Info.

**The main goals I had were.**

* Professional code quality
* Easy extensibility for future features
* Realistic Login and Register
* Accurate results on Calculator
* User did not have to insert his username again on UserInfo

# **UML Diagram**

![](data:image/png;base64...)

## **Solution Design**

**Conversion abstract class**

The Conversion class is an abstract class that manages the conversions done in the calculator. It is the super class of all they type of conversions

**Attributes (Protected)**:

The attributes that the Conversion class has are:

The name, which gives you the name of the conversion, the definition, which would give you a short definition of the Conversion( kind of like Decimal To Binary), the bitSize, which is necessary for some conversions, and finally the validator, which comes from another class.

**Methods (Public):**

* Conversion(): Constructor.
* GetName(): Returns the name of the Conversion
* GetDefinition(): Returns the definition of the conversion
* NeedBitSize(): Returns whether the Bit size is needed or not
* Validate():Validates the input
* Change():Does the conversion of the number

**CalculatorPage Class:**

The CaclulatorPage class is the one in charge of the calculator, where he receives the inputs, and uses a list, to do the conversion of the number

**Attributes(private):** The attributes that the CaclulatorPage class contains are:conversions, and currentUser.

These attributes are used for different things. First of all conversions is a List that stores all the conversions, so that they can be used. Then, currentUser, holds the user that has logged in the application, so that it can count operations

Both of them are private attributes

**Methods(Public):**

* CalculatorPage(): Constructor
* OnInputButtonClicked(): Shows the input when you pressed it
* OnClearClicked(): Clears the box where the numbers are showed
* OnConversionClicked(): Converts the input shown through the box, on the type of conversion you pressed.
* OnShowUserInfo(): Gets you to the UserInfo page
* OnExitClicked(): Closes the program when pressed

**LoginPage Class:**

The Loginclass is the one in charge of the Login, where he receives the inputs, and calls a method in UserStore, to see if both are saved in the csv file

**Attributes(private):** The attributes that the LoginPage class contains are:userStore, and loginUser.

These attributes are used for different things. First of all, userStore is used to sign-in, as the methods of validating the login are in the class UserStore. Then, loginUser, holds the user that has logged in the application, so that it can keep track of the things that user is doing

Both of them are private attributes

**Methods:**

* LoginPage(): Constructor, where we implement the buttons to the register page and forgot password
* OnLoginClicked(): Sends the user and password to the method that validates them, and if they are correct, leads you to the Calculator Page.
* GetUser(): It stores the user that has logged in, so it can be sent to the next pages, and it keeps storing the information
* OnExitClicked(): Closes the program when pressed

**RegisterPage Class:**

The RegisterPage is the one in charge of the Register, where he receives all the inputs, and calls a method in UserStore so that the information is saved in the csv, if it is correct. The attribute is private

**Attributes(private):** The only attribute of RegisterPage is userStore, which as the one we also used in the LoginPage class, it is used so that we can use a method in it, which is the one in charge of making sure the information gets in the csv.

**Methods:**

* RegisterPage(): Constructor
* OnRegisterClicked(): Sends all the information the method that uploads them in the csv , and checks they are correct, leads you to the Calculator Page.
* OnExitClicked(): Closes the program when pressed

**ForgotPasswordPage Class:**

The ForgotPasswordPage is the one in charge of giving back the password, if you forgot about it by entering your email.

**Attributes(private):** ForgotPasswordPage, doesn’t have any attributes, it just holds the file path to the csv.

**Methods:**

* ForgotPasswordPage(): Constructor
* OnSendClicked(): When the button is clicked, the method searches through the users to find the email, and if it exists, it gives you back the password.
* OnExitClicked(): Closes the program when pressed

**UserInfo Class:**

The UserInfo is the one in charge of giving back all the information including the number of operations that person that is logged in did

**Attributes(private):** UserInfor, doesn’t have any attributes.

**Methods:**

* UserInfo(): Constructor, which receives the user, and displays all of his information
* OnBackClicked(): Gets you back to the calculator
* OnExitClicked(): Closes the program when pressed

**User Class:**

The User is a class to create Users, and it has been used for passing through users from one class to another

**Attributes:** User has five public attributes with his gets and sets. His attributes are the nes that the user has to fill in the register, plus another one: the name, the username, the email the password, and the number of operations, to keep count of them

**Methods:**

User does not have any methods.

**UserStore Class:**

The UserStore class was made for one reason, and it’s because I didn’t want to use too much the csv around all the pages, so this one keeps the Register, and other pages from accessing to the csv, that’s why there are some methods that are created here

**Attributes(private):** UserStore, doesn’t have any attributes.

**Methods:**

* UserStore(): Constructor
* RegisterUser(): Checks the values sent, and inserts them into the csv.
* IsValidPassword(): Checks if the password is valid, as you need to insert a password with at least one Upper case letter, a Lower case letter, a symbol, and a number, and the password has to be of eight letter or more
* LoginUser(): Checks if the username and the password of the login are correct, looking for them in the same line of the csv.

**InputValidatorClass:**

The InputValidator is an abstract class that checks if the input that was written, is valid or not, and has a branch to check for each conversion

**Attributes(private):** InputValidator, doesn’t have any attributes.

**Methods:**

* validate(): It validates the input that it receives

#

# **Problems**

**Problems with Maui**

One of the most problems I had was that sometimes whenever I was coding, as it was one of the first times coding in Maui, there were lots of mistakes, and most of it came because of the namespace, as sometimes I didn’t insert the namespace correctly, and everything gave me error, which wasn’t a difficult error. However the big problem of changing the namespace as I did, because I made a grammatical error, was that it gave me error everywhere, and I was no longer even able to follow the errors I had, as they were everywhere, so what I finally ended up doing, is creating a new github repository, where I could start again, even though it wasn’t the best option, I wasn’t getting anywhere with all the errors I had. I finally ended up writing correctly the namespace the first time I did it, so it all went a lot better. At some points I also had some problems in general with Maui, as sometimes I randomly got errors on the InitializeComponent(), or other figures, but eventually I figured them out, as I went through little by little.

**Problems with the .csv File**

One of the problems I had at the moment of trying the application, was that on every page, it was telling me that the .csv file wasn’t found, and I tried with different relative routes, but nothing was working, because I was putting the routes wrong. At the end, doing some research through Visual Studio, I ended up finding an option that was copying the relative path. So I spent some time trying to find out the relative path by trying, and the answer was just to copy the relative path.

**Problems with connecting the Activity VII**

Finally, one of the last problems I had, was that at first I didn't’ really know how did I have to implement the activity VII on the Maui, even though it was one of the first things I had to do, I had to do some research on how to do it, but I ended up realizing, that it was actually hard, and so I copied all of the .cs of the activity VII on a new file called Calculator, inside the practical\_work\_ii, where I excluded the program, and changed the namespace, to the one the other .cs were using. Finally, I didn’t use the converter.cs , and instead did most of the things the converter did, but in the CalculatorPage.

# **Conclusions**

I have come to the conclusion that doing this project has been a fulfilling and rewarding experience for me. It has challenged me within how do I solve some problems, and on my thinking and understanding capacities, which has helped me to learn a bit more about C#,and really helped me to understand and comprehend Maui, along to learn about it, and its relations with C#.

I have also come to the conclusion that this project has helped me to understand, that not always you are going to be able to work with other people, and that there are some things that you have to do on your own to become also more helpful when other people need you for coding, and in the development of projects.

As for the effectiveness of the solutions I developed, I had to work it out little by little, as it wasn’t that easy, and even though I had some complications in some parts of the code, I believe that doing this project has had a positive impact on me, and has taught me an important lesson about managing my time, and organize myself to do different things like studying, and developing projects on my own. With this project I have also reached the conclusion that this career shows you that it is important to work in a team, but you cannot rely always on having a team to help you on the projects, and you have to do some things individually, even if it is harder, it helps me grow, and be more helpful in other times.

