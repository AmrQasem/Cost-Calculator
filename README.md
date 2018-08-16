






#API Reference Manual

[API Documentation Guidelines](http://idratherbewriting.com/learnapidoc/#from-practice-to-documentation)


##**[Resource: Categories]**
**Category**  is the service type that the client requests to know its quotation price (ex: Standard Quality Translation, Premium Quality Translation)

##Endpoints

- Create 
1. **POST /category** 
Description: Create a new category
- Read 
1. **GET/category** 
Description: Get All Categories
2.  **GET/category/{ID}**
Description:  	Get information about a specific categories
- Edit 
1. **PUT/category/{ID}**
Description:  	Update the information of the specific category
- Delete 
1. **DELETE/category/{ID}** 
Description: 	Delete the information of the specific category

##Parameters
 **POST/category**
>**CategoryName** _String_  
Example: Standard
>**UnitPrice** _Double_
Example: 0.2
>**WorkRate** _int_
Example: 5200


**GET/category/{ID}** 
>**ID**  _int_ 
 Example: 1 

**PUT/category/{ID}**
>**ID**  _int_ 
 Example: 1 
>**CategoryName** _String_  
Example: Standard
>**UnitPrice** _Double_
Example: 0.2
>**WorkRate** _int_
Example: 5200

**DELETE/category/{ID}**
>**ID**  _int_ 
 Example: 1 

##Examples

###**POST/category**
**Request**

`
{"CategoryName":"Standard","UnitPrice":0.2,"WorkRate":5200}
`

**Response**
>**On Success**
`HTTP/1.1 201 Created`

>**On Error** (ex: parameter = null ): 
`HTTP/1.1 400 Bad Request`


###**GET/category/{ID}**

**Response**
>**On Success**
`HTTP/1.1 200 OK`
**Body**
>{
  "ID": 1,
  "CategoryName": "Standard",
  "UnitPrice": 0.05,
  "WorkRate": 2000
}

>**On Error** (ex: id is not found in database ):
`HTTP/1.1 404 Not Found`

###**- PUT/category/{ID}**

**Request**
`
{"CategoryName":"Preimum","UnitPrice":0.2,"WorkRate":5200}
`
**Response**
>**On Success**
`HTTP/1.1 201 Created`

>On Error(ex: id is not found in database or any parameter = null ): 
`HTTP/1.1 404 Not Found`

###**- DELETE/category/{ID}**
**Response**
>**On Success**
`HTTP/1.1 201 OK`

>On Error(ex: id is not found in database or any parameter = null ): 
`HTTP/1.1 404 Not Found`

##**[Resource: Languages]**
**Languages** is the service that help users to choose Source Language and Target language(ex: English, Arabic, German)
##Endpoints

- Create 
1. **POST /language**
Description:  Create a new Language
- Read 
1. **GET/language** 
Description: Get All language 
2.  **GET/language/{language ID}**
Description:  	Get information about a specific language 
- Edit 
1. **PUT/language/{language ID}**
Description:  	Update the information of the specific language 
- Delete 
1. **DELETE/language/{language ID}**
Description:  	Delete the information of the specific language 

## Parameters
 **POST/language**
>**Name** _String_  
Example: English


**GET/language/{ID}** 
>**ID**  _int_ 
 Example: 1 

**PUT/language/{ID}**
>**ID**  _int_ 
 Example: 1 
>**Name** _String_  
Example: English

**DELETE/language/{ID}**
>**ID**  _int_ 
 Example: 1 

##Examples
###**POST/language**
**Request**
`
{"Name":"German}
`
**Response**
>**On Success**
`HTTP/1.1 201 Created`

>**On Error** (ex: parameter = null ): 
`HTTP/1.1 400 Bad Request`

###**- GET/language/{ID}**
**Response**
>**On Success**
`HTTP/1.1 201 OK`
>{
  "ID": 1,
  "Name": "English"
}

>On Error (ex: id is not found in database): 
`HTTP/1.1 404 Not Found`

###**- PUT/language/{ID}**

**Request**
`
{"Name":"German}
`
**Response**
>**On Success**
`HTTP/1.1 201 Created`

>On Error (ex: id is not found in database or any parameter = null ): 
`HTTP/1.1 404 Not Found`

###**- DELETE/language/{ID}**
**Response**
>**On Success**
`HTTP/1.1 201 OK`

>On Error (ex: id is not found in database or any parameter = null ): 
`HTTP/1.1 404 Not Found`

##**[Resource: Subjects]**
**Subjects**  is the service type that the client requests to know its quotation price (ex: General Subject, Technical Subjects)

##Endpoints

- Create 
1. **POST /subject**
Description:  Create a new subject 
- Read 
1. **GET/subject** 
Description: Get All Categories
2.  **GET/subject/{ID}**
Description:  	Get information about a specific subjects 
- Edit 
1. **PUT/subject/{ID}**
Description:  	Update the information of the specific subject 
- Delete 
1. **DELETE/subject/{ID}** 
Description: 	Delete the information of the specific subject 


##Parameters
 **POST/subject**
>**SubjectTitle** _String_  
Example: General

**GET/subject/{ID}** 
>**ID**  _int_ 
 Example: 1 

**PUT/subject/{ID}**
>**ID**  _int_ 
 Example: 1 
>**SubjectTitle** _String_  
Example: General

**DELETE/subject/{ID}**
>**ID**  _int_ 
 Example: 1 

##Examples
###**POST/subject**
**Request**
`
{"SubjectTitle":"General}
`
**Response**
>**On Success**
`HTTP/1.1 201 Created`

>On Error (ex: any parameter = null ): 
`HTTP/1.1 400 Bad Request`

###**- GET/subject/{ID}**
**Response**
>**On Success**
`HTTP/1.1 200 OK`
>[
  {
    "ID": 1,
    "SubjectTitle": "General"
  },
]
>On Error (ex: id is not found in database): 
`HTTP/1.1 404 Not Found`


###**- PUT/subject/{ID}**

**Request**
`
{"SubjectTitle":"General}
`
**Response**
>**On Success**
`HTTP/1.1 201 Created`

>On Error (ex: id is not found in database or any parameter = null): 
`HTTP/1.1 404 Not Found`

###**- DELETE/subject/{ID}**
**Response**
>**On Success**
`HTTP/1.1 201 OK`

>On Error (ex: id is not found in database or any parameter = null): 
`HTTP/1.1 404 Not Found`












































##**[Resource: Quotation]**
**Quotation**  is the service type that the client can know the quotation price 

##Endpoints

- Create 
1. **POST /quotation**
Description:  Create and request new Quotation Calculation 


##Parameters
 **POST/quotation**
>**FromLangID** _Int_  
Example: 1

>**ToLangID** _Int_  
Example: 2

>**WordCount** _double_  
Example: 3500

>**SubjectID** _Int_  
Example: 1

>**IsRush** _bool_  **Optional**
Example: false

>**RushDate** _datetime_ **Optional**  
Example: "21-8-2018"

>**CategoryID** _Int_  **Optional**
Example: 1

##Examples
###**POST/subject**
**Request**
`
{"FromLangID" : 1,"ToLangID" : 2, "WordCount" : 3500 ,"SubjectID":1}
`
**Response**
>**On Success**
`HTTP/1.1 201 Created`
**Body**
{
  "ID": 1041,
  "FromLangID": 1,
  "ToLangID": 2,
  "WordCount": 3500,
  "IP_Address": "192.168.0.239",
  "IsRush": null,
  "RushDate": "0001-01-01T00:00:00",
  "QuotaionDetailsList": [
    {
      "ID": 0,
      "Category": {
        "ID": 1,
        "CategoryName": "Standard",
        "UnitPrice": 0.05,
        "WorkRate": 2000
      },
      "StartDate": "2018-08-16T00:00:00+02:00",
      "EndDate": "0001-01-01T00:00:00",
      "Price": 175,
      "NumberOfDays": 2,
      "Ratio": 0.02,
      "RushRatio": 0.1,
      "SubjectRatio": 0.1,
      "NumberOfRushDays": 0,
      "RushDate": "0001-01-01T00:00:00"
    },
    {
      "ID": 0,
      "Category": {
        "ID": 2,
        "CategoryName": "Preimum",
        "UnitPrice": 0.08,
        "WorkRate": 1500
      },
      "StartDate": "2018-08-16T00:00:00+02:00",
      "EndDate": "0001-01-01T00:00:00",
      "Price": 280,
      "NumberOfDays": 2,
      "Ratio": 0.02,
      "RushRatio": 0.1,
      "SubjectRatio": 0.1,
      "NumberOfRushDays": 0,
      "RushDate": "0001-01-01T00:00:00"
    }
  ],
  "Subject": {
    "ID": 1,
    "SubjectTitle": null
  },
  "CategoryDMList": [
    {
      "ID": 1,
      "CategoryName": "Standard",
      "UnitPrice": 0.05,
      "WorkRate": 2000
    },
    {
      "ID": 2,
      "CategoryName": "Preimum",
      "UnitPrice": 0.08,
      "WorkRate": 1500
    }
  ],
  "StartDate": "2018-08-16T11:49:48.7440225+02:00",
  "CategoryID": null
}

>On Error (ex: any parameter = null ): 
`HTTP/1.1 400 Bad Request`




#**Note**
**Each and every request have header** 
>Accept: application/json
Content-Type: application/json
































# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://www.visualstudio.com/en-us/docs/git/create-a-readme). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)