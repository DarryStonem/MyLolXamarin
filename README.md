# MyLoLXamarin
A League of Legends app using Xamarin Forms.

**Android** [![Build status](https://build.appcenter.ms/v0.1/apps/150743b4-f187-4e54-b973-e25df37608d2/branches/master/badge)](https://appcenter.ms) 

**iOS** [![Build status](https://build.appcenter.ms/v0.1/apps/837ee705-5f24-4760-810c-d5b7a29986b0/branches/master/badge)](https://appcenter.ms)

**Android Bitrise**
[![Build Status](https://app.bitrise.io/app/47e3ef511a608aed/status.svg?token=h8AGaVMJHtWBLEp0SsMsQw&branch=master)](https://app.bitrise.io/app/47e3ef511a608aed)

## Setup project

In order to make this app works, you must have Visual Studio 2019 with the latest tools for Xamarin development. You can get it here: [Download Visual Studio](http://visualstudio.com).

Also, **Riot Games requires an API key from their developer portal**. You can get it [here](https://developer.riotgames.com/). The development key only last for 24 hours, so you need to consistently change it or ask for a production one, but it will take a while for approval. 

This project also uses [AppCenter](http://appcenter.ms) for Analytics and Crashes reporting, and it uses the free version! You can create an account and get the API Keys for usage.

In `Source/MyLoL/Constants.cs` you can change the variables for local usage. `APIKEY`, `AppCenteriOS` and `AppCenterAndroid`. This should make the project works using emulator. 

It doesn't matter if you run the app locally using a simulator. You can have your information right in the mobile app :) 

## Credits

### Libraries used
This app uses [RiotSharp](https://github.com/BenFradet/RiotSharp) for getting the Riot Games data. A big thanks for them!
