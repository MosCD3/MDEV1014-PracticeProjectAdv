using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MDEV1014PracticeProject.ViewModels;
using MDEV1014PracticeProject.Views;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> mappings;
        protected Application CurrentApplication => Application.Current;
        private Page CurrentPage;



        public NavigationService()
        {

            //Debug.WriteLine($"######## NavigationService[{this.GetHashCode()}] ########");
            mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }


        /// <summary>
        /// Create View/ViewModel mapping
        /// Any created page should be declared here 
        /// </summary>
        void CreatePageViewModelMappings()
        {
            mappings.Add(typeof(ContactDetailsPageVM), typeof(ContactDetailsPage));
        }




        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public void LogoutUserAsync()
        {
            //var loginPage = GetPage<LoginViewModel>();
            //CurrentApplication.MainPage = new NavigationPage(loginPage);

        }





        public Page GetPage<TViewModel>() where TViewModel : ViewModelBase => CreateAndBindPage(typeof(TViewModel), null);


        //Main navigation action function
        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase => InternalNavigateToAsync(typeof(TViewModel), null);

        //Main navigation action function with parameters
        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase => InternalNavigateToAsync(typeof(TViewModel), parameter);


        //Get current page, used by other services to get current displayed page (Context)
        public Page GetCurrentPage()
        {
            return CurrentPage;
        }

        public Task PopLastAsync()
        {
            if (CurrentPage != null)
            {
                return CurrentPage.Navigation.PopAsync();
            }
            else
            {
                Debug.WriteLine("Error! Nav Service, PopLastAsync Current page null");
                return null;
            }
        }


        /// <summary>
        /// Returns a navigation task 
        /// </summary>
        /// <param name="viewModelType"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            try
            {
                var page = CreateAndBindPage(viewModelType, parameter);

                if (page == null)
                {
                    Debug.WriteLine($">> Stopping navigation, page null!");
                    return;
                }

                if (page is Shell)
                {
                    CurrentApplication.MainPage = page;

                }
                else if (page is FlyoutPage)
                {
                    CurrentApplication.MainPage = page;
                }
                //else if (page is ExtendedSplash)
                //{
                //    CurrentApplication.MainPage = new NavigationPage(page);

                //}
                else if (CurrentApplication.MainPage is NavigationPage navigationPage)
                {
                    await navigationPage.PushAsync(page);
                }
                else if (CurrentApplication.MainPage is FlyoutPage masterDetailPage)
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(page);
                }
                else if (CurrentApplication.MainPage is Shell shellPage)
                {
                    await shellPage.CurrentPage.Navigation.PushAsync(page);
                }
                else
                {
                    Debug.WriteLine($"Error> NavService, cannot detect what page type:{CurrentApplication.MainPage.GetType()}");
                    CurrentApplication.MainPage = new NavigationPage(page);
                }

                //if everything goes fine, set current page
                CurrentPage = page;
                //Debug.WriteLine($"Iam :{this.GetHashCode()}");
                //Debug.WriteLine($"Setting current page to:{CurrentPage}");
                await (page.BindingContext as ViewModelBase)?.InitializeAsync(parameter);
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error Navigation service> Exception Internal Nav:{e.Message}");
            }

        }

        /// <summary>
        /// Internal function create the page, create ViewModel using Autofac
        /// to support dependency injection then bind view to view model
        /// </summary>
        /// <param name="viewModelType"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                Debug.WriteLine("ERROR! NavService> Mapping type for {viewModelType} is not a page");
                return null;
            }
            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = Locator.Instance.Resolve(viewModelType) as ViewModelBase;
            Debug.WriteLine("set binding context");
            page.BindingContext = viewModel;

            return page;
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
            {
                Debug.WriteLine("ERROR! NavService> No map for ${viewModelType} was found on navigation mappings");
                return null;
            }
            return mappings[viewModelType];
        }

    }
}
