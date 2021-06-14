# MMT Senior Server Side .Net : Technical Test

* Project created on netcoreapp3.1
* Solution has API, Common, Core and Data
* API is light weight to receive and respond to the request.
* Common proj has genric needs between all projects in sln.
* Core is responsible to talk to third party api's.
* Data is responsible for Entities, Repos and context needed for data pulling from DB.

##### Important points:

* To catch global exception a inline middleware is been added in startup file, this can be moved to a new files too.
* appsettings.json has all required configs i have't sepertated to dev or prod.
* In Appsettings json, UserAPIsettings has both API and UserAPI configs like timeout and apikey can be seperated.
* Internal ILogger is been used in very few places just to show how it can be done. We can have somethirdparty too like nlog with a customer logger class for ease regex.
* Haven't added any unit/integration tests i believe the ask is for api's only.
* All Entities are written not used any EF tools to auto generate.
* Haven't used any mappers.
* Added Cors AnyOrigin but didn't added any api request authentication like token(JWT), good to have unless if it's public.

###### Only public repo's available in my Github account so, I have removed APIkey and connection strings from appsettings json while pushing.
