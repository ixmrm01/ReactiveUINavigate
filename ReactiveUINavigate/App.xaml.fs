namespace ReactiveUINavigate

open Xamarin.Forms

type App() as this =
    inherit Application()

    do
        let bootstrapper = new AppBootstrapper()
        this.MainPage <- bootstrapper.CreateMainPage()

    override this.OnStart() =
        base.OnStart()

    override this.OnSleep() =
        base.OnSleep()

    override this.OnResume() =
        base.OnResume()
