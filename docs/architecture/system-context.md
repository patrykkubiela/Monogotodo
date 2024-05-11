System Context Diagram
----------------------

This diagram describes MonogotoDo system context.

<h1 align="center">
  <img src="temp" alt="Monogotodo">
</h1>

Here is code for it written in [scructurzr](https://structurizr.com):

```
workspace {
    model {
        user = person "MonogotoDo User"
        softwareSystem = softwareSystem "MonogotoDo System" {
            user -> this "Uses"
        }
    }

    views {
        systemContext softwareSystem {
            include *
            autolayout lr
        }

        container softwareSystem {
            include *
            autolayout lr
        }

        theme default
    }

}
```