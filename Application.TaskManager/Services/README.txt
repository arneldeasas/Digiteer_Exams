Notes:

I chose to create a service folder inside the Application layer to contain the Password-Hashing service. 
Usually, this is placed in the Infrastructure layer, but since for the sake of simplicity, I am not creating a separate project for Infrastructure just for this service.

What matters is that the use-cases that need the password-service is depending on an abstraction and we can easily swap the implementation later if needed 
(e.g deprecated package or became unsupported).