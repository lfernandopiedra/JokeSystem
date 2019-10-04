# JokeSystem
BairesDevTest
How to run the code:

To run this code, IIS and .Net Framework 4.7.2 are required. 

Project definition The system reads from an external joke repository (https://icanhazdadjoke.com), Querying to the API; The repository returns a JSON string, which can be treated as follows

Check every 10 seconds of jokes randomly
Query by search parameter.

If a search is performed, the system classifies and displays the jokes resulting from the query according to its length. It also highlights the term searched in uppercase and bold letters.

The system was designed following an MVC model; in which a parent class (Joke) and a search, classification, word count and search results (JokeService) service were established. The controllers trigger the methods and publish the results in the views.
