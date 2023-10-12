# CDR BI Platform Technical Test

## Assumptions
API is connected to some storage. Singleton has been used to emulate.

Due to lack of storage, all calls are synchronous.

Provided CSV is one of many files that will be uploaded.

Swagger can be used for API documentation

## Decisions
DDD

Defensive programming approach: objects can never be null to reduce exceptions. Leave validation of dataset to the consumer.

Internal Exceptions are hidden.

One API Project + One Test Project

Generated a new CSV to be more reflective of desired functionality in test cases

## Differently
For better maintainability:

- Models exist in there own class project

- Service Layer exists in its own project

- Singleton would be replaced by Repository Layer with storage context

- Moq instead of hard coded dataset for testing

