# MMT Digital Tech Test

This is my submission to MMT Digital for their first stage interview.

## Setup

* Ensure you have the [dotnet SDK](https://dotnet.microsoft.com/download) installed for your system.

* Open your SQL DB manager and start a new query.  Copy and past the contents of **database/db_schema.sql** into this query and run it.

* Create (if desired) or grant an existing user the appropriate permissions to view the database and its schemas.

* Follow the instructions [here](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=linux) to activate Secrets Manager and set up your DB connection string with the key **Db:ConnectionString** and relevant db and user details.

* Create a self-signed SSL certificate by running `dotnet dev-certs https --clean` then `dotnet dev-certs https --trust`.  If you're on Windows, remove the `Kestrel` block from `appsettings.json`.  If you're on a Linux system, refer to [these instructions](https://stackoverflow.com/questions/55485511/how-to-run-dotnet-dev-certs-https-trust) instead to set up the SSL certificate.

## Testing

* Open a command line terminal, `cd <your-local-filepath>/mmt-tech-test/api.tests` and enter `dotnet test`.

## Running

* Open two command line terminals.

* In one `cd <your-local-filepath>/mmt-tech-test/api` and enter `dotnet run`.

* With the api running, in the other terminal `cd <your-local-filepath>/mmt-tech-test/console-app` and enter `dotnet run`.  You should see the data from the database print to the terminal.