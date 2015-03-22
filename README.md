# fifi-server

### Get Report categories
http://squeakycitizen.azurewebsites.net/api/report/categories

### Get Reported Interactions (Incidents)
http://squeakycitizen.azurewebsites.net/api/report/interaction

### Get Reported Interaction (Incident) by Id
http://squeakycitizen.azurewebsites.net/api/report/interaction/{id}  
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
