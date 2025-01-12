#Polly

## Transient Faults?
- errors that happen for only a short amount of time.
- examples:
    - network error blocking API/DB
    - Microservice startup
    - Server refusing connections due to server load

### Why do we care?
- If handled correctly:
    - rather than getting an error and accepting failure
    - we could eventually get a successful response
- This is particularly useful in Microservice app architectures.

## Handling Transient Faults
- 'Retry Policy' is our main focus (try it again to see if it succeeds)
- Configurable:
    - number of retries
    - exponential backoff

### Policy 1 - Retry Immediately 5x