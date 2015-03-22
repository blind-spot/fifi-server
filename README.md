# fifi-server

### Get Report categories  
http://squeakycitizen.azurewebsites.net/api/report/categories  

### Get Reported Interactions (Incidents)  
http://squeakycitizen.azurewebsites.net/api/report/interaction  
return array of reported interaction objects  

### Get Reported Interaction (Incident) by Id
http://squeakycitizen.azurewebsites.net/api/report/interaction/1  
Return:  
{
"Id": 1,
"Location": {
"Lat": 45.71211242675781,
"Long": -121.5271987915039,
"Cross_Street": "301 15th Street, Hood River",
"Narrative": "test"
},
"Mode": "Bike",
"Description": "Doored on 2nd n seneca",
"Incident_Time": "2015-03-20T00:00:00",
"Image": null,
"Infrastructure": false,
"Collision": false,
"PropertyDamage": false,
"Injury": false,
"Modes": {
"Personal": "Bike",
"Other": null
}
},

### Post Interaction Report
http://squeakycitizen.azurewebsites.net/api/report/interaction/
Sample Post Json  
{  
    "Location":  
        {  
            "Lat":45.712112426757812,  
            "Long":-121.52719879150391,  
            "Address":"301 15th Street, Hood River",  
            "Narrative":"test"  
        },  
    "Mode":"Bike",  
    "Description":"Test Doored on 2nd n seneca"  
}

Return:  
{
    "Id": 3,  
    "Location":
        {
            "Lat":45.712112426757812,  
            "Long":-121.52719879150391,  
            "Address":"301 15th Street, Hood River",  
            "Narrative":"test"  
        },  
    "Mode":"Bike",  
    "Description":"Test Doored on 2nd n seneca"  
}


### Upload Image
http://squeakycitizen.azurewebsites.net/api/report/UploadImage/{id}
form-data key = image


### Simple Map
http://squeakycitizen.azurewebsites.net/map/
Show all reports