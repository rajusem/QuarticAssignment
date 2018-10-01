*******Briefly describe the conceptual approach you chose! What are the trade-offs?*******
-Model
Created different models to store Signal data as well as Rule Data.  
-Business Logic
Created RuleEngine business class that does validation. It will use factory to get relavant validator(Integer/String/DateTime) based on ruletype supplied, which underlying calls specific validator. So, we can change/add new validator easily without effecting others.



******What's the runtime performance? What is the complexity? Where are the bottlenecks?******
2 Rule - Int + String, 400 Signal records - 6 ms 
2 Rule - Datetime , 400 Signal records  - 4 ms
1 Rule - String , 400 Signal records - 3 ms
Bottleneck : We are using only one thread to process data, not doing validation in distributed fashion so it take more time once we have huge data. 




******If you had more time, what improvements would you make, and in what order of priority?******
1) Validator Factory will change it to singleton so each time no need to create validator object we can reuse the singleton benefits.
2) Parallel data processing to improve performance.  
