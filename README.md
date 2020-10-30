# Parks


## About / Synopsis

* This project tracks a parks keeping track of location, name, park type and a description.
* This project was created following Epicodus' Api Independent Project's requirments.
* Project status: working
* Created by: Joseph Nilles 10/30/20



## Table of contents


> * [Parks](#parks)
>   * [About / Synopsis](#about--synopsis)
>   * [Table of contents](#table-of-contents)
>   * [Setup](#setup)
>   * [Usage](#usage)
>     * [Screenshots](#screenshots)
>     * [Features](#features)
>   * [Code](#code)
>     * [Bugs](#bugs)
>     * [To Do](#to-do)
>   * [Resources (Documentation and other links)](#resources-documentation-and-other-links)
>   * [Contact](#contact)
>   * [License](#license)


## Setup

* Clone the project from the repository at https://github.com/jbnilles/Parks
* Navigate to the project file and then into the folder `Factory`
* Create a file called `appsettings.json`
* In the `appsettings.json` file add the following
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=joseph_nilles;uid=root;pwd=YOUR_PASSWORD;"
  }
}
```
* Replace `YOUR_PASSWORD` with you MySQL password
* Open a terminal and navigate to the `Park` folder inside the project 
* In the terminal run `dotnet ef database update`
* In the terminal run `dotnet run`
* Open a web browser and go to http://localhost:5000/ 




## Usage

#### Endpoints

Base URL: `http://localhost:5000`

#### HTTP Request

```
GET /api/parks
POST /api/parks
GET /api/parks/{id}
PUT /api/parks/{id}
DELETE /api/parks/{id}
GET /api/parks/search
Get /api/parks/random
```

#### Path Parameters

# GET /api/parks/search
| Parameter |  Type  | Default | Required | Description                      |
| :-------: | :----: | :-----: | :------: | -------------------------------- |
|  state    | string |  none   |  false   | Return matches by State. |
|   city    | string |  none   |  false   | Return matches by city.     |
|  TypeOfPark  | string |  none   |  false   | Return matches by type of park.  |
|  pageSize   |  int   |  none   |  false   | determines how many records to show per page.  |
|  pageNumber   |  int   |  none   |  false   | determines which page of results  |

# GET /api/parks, POST /api/parks
| Parameter |  Type  | Default | Required | Description                      |
| :-------: | :----: | :-----: | :------: | -------------------------------- |
|  pageSize   |  int   |  none   |  false   | determines how many records to show per page.  |
|  pageNumber   |  int   |  none   |  false   | determines which page of results  |

# GET /api/parks/{id}, PUT /api/parks/{id}, DELETE /api/parks/{id}
| Parameter |  Type  | Default | Required | Description                      |
| :-------: | :----: | :-----: | :------: | -------------------------------- |
|  id   |  int   |  none   |  false   | id of park  |
|  pageSize   |  int   |  none   |  false   | determines how many records to show per page.  |
|  pageNumber   |  int   |  none   |  false   | determines which page of results  |

# Get /api/parks/random
| Parameter |  Type  | Default | Required | Description                      |
| :-------: | :----: | :-----: | :------: | -------------------------------- |

#### Example Query

```
http://localhost:5000/api/parks/
```
#### Sample JSON Response

```
{
    {
    "pageNumber": 1,
    "pageSize": 10,
    "firstPage": "http://localhost:5000/api/parks?pageNumber=1&pageSize=10",
    "lastPage": "http://localhost:5000/api/parks?pageNumber=1&pageSize=10",
    "totalPages": 1,
    "totalRecords": 5,
    "nextPage": null,
    "previousPage": null,
    "data": [
        {
            "parkId": -5,
            "typeOfPark": "National",
            "city": "Mount Rainier",
            "state": "WA",
            "name": "Mount Rainier National Park",
            "description": "Mount Rainier National Park, a 369-sq.-mile Washington state reserve southeast of Seattle, surrounds glacier-capped, 14,410-ft. Mount Rainier."
        },
        {
            "parkId": -4,
            "typeOfPark": "National",
            "city": "Lake Chelan",
            "state": "WA",
            "name": "North Cascades National Park",
            "description": "North Cascades National Park is in northern Washington State. It’s a vast wilderness of conifer-clad mountains, glaciers and lakes."
        },
        {
            "parkId": -3,
            "typeOfPark": "National",
            "city": "Port Angeles",
            "state": "WA",
            "name": "Olympic National Park",
            "description": "Olympic National Park is on Washington's Olympic Peninsula in the Pacific Northwest. The park sprawls across several different ecosystems, from the dramatic peaks of the Olympic Mountains to old-growth forests."
        },
        {
            "parkId": -2,
            "typeOfPark": "State",
            "city": "Brinnon",
            "state": "WA",
            "name": "Dosewallips State Park",
            "description": "Dosewallips State Park is a public recreation area located where the Dosewallips River empties into Hood Canal in Jefferson County, Washington."
        },
        {
            "parkId": -1,
            "typeOfPark": "State",
            "city": "Pouslbo",
            "state": "WA",
            "name": "Kitsap Memorial State Park",
            "description": "Kitsap Memorial State Park is a 63-acre public recreation area located on Hood Canal, seven miles north of Poulsbo in Kitsap County, Washington."
        }
    ],
    "succeeded": true,
    "errors": null,
    "message": null
}
}
```
#### Example Query

```
http://localhost:5000/api/parks?city=poulsbo&pagesize=1&pagenumber=1
```

#### Sample JSON Response

```
{
    "pageNumber": 1,
    "pageSize": 1,
    "firstPage": "http://localhost:5000/api/parks?pageNumber=1&pageSize=1",
    "lastPage": "http://localhost:5000/api/parks?pageNumber=5&pageSize=1",
    "totalPages": 5,
    "totalRecords": 5,
    "nextPage": "http://localhost:5000/api/parks?pageNumber=2&pageSize=1",
    "previousPage": null,
    "data": [
        {
            "parkId": -5,
            "typeOfPark": "National",
            "city": "Mount Rainier",
            "state": "WA",
            "name": "Mount Rainier National Park",
            "description": "Mount Rainier National Park, a 369-sq.-mile Washington state reserve southeast of Seattle, surrounds glacier-capped, 14,410-ft. Mount Rainier."
        }
    ],
    "succeeded": true,
    "errors": null,
    "message": null
}
```

### Features
* Add/Edit/Delete/View Parks
* Get a random park
* Search parks by name, city, state or type

## Code

### Bugs

* No known bugs

### To Do

  - [ ] Add a reviews table to allow for connecting reviews to the parks
  - [ ] Add Api versioning
  - [ ] Add Authentication/ Authorization
  - [X] Add Swagger
  - [X] Add Pagination


## Resources (Documentation and other links)




## Contact

To contact author 
  * Email Joseph Nilles at jbnilles24@gmail.com
  * Github : github.com/jbnilles

## License

This project is licensed using MIT License

