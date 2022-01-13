# Basket Kata

What is this? An implementation for a tech test demonstrating basic coding and testing in c#. This is a throwaway coding kata.

## Status

### Github Actions CI

[![.NET](https://github.com/timabell/basket-kata/actions/workflows/dotnet.yml/badge.svg)](https://github.com/timabell/basket-kata/actions/workflows/dotnet.yml)

# Dependencies

dotnet version controlled by [asdf-vm](https://asdf-vm.com/)

# Where to start

* Executable BDD Gherkin for the original spec [specs/Discounts.feature](specs/Discounts.feature)
* Other unit tests (`*Tests.cs`) in [specs/](specs/)
* Runtime library code is in [BasketLib/](BasketLib/)

# API

```
cd api
dotnet run
```

API docs can be found at <https://localhost:7187/swagger/> when running the app locally.
