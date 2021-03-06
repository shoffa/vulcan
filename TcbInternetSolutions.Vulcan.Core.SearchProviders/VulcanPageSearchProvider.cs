﻿namespace TcbInternetSolutions.Vulcan.Core.SearchProviders
{
    using EPiServer;
    using EPiServer.Core;
    using EPiServer.DataAbstraction;
    using EPiServer.Framework.Localization;
    using EPiServer.ServiceLocation;
    using EPiServer.Shell;
    using EPiServer.Shell.Search;
    using EPiServer.Web;
    using TcbInternetSolutions.Vulcan.Core;

    /// <summary>
    /// UI search provider for PageData
    /// </summary>
    [SearchProvider]
    public class VulcanPageSearchProvider : VulcanSearchProviderBase<PageData>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VulcanPageSearchProvider()
              : this(
                    ServiceLocator.Current.GetInstance<IVulcanHandler>(),
                    ServiceLocator.Current.GetInstance<LocalizationService>(),
                    ServiceLocator.Current.GetInstance<ISiteDefinitionResolver>(),
                    ServiceLocator.Current.GetInstance<IContentRepository>(),
                    ServiceLocator.Current.GetInstance<IContentTypeRepository>(),
                    ServiceLocator.Current.GetInstance<UIDescriptorRegistry>()
                )
        { }

        /// <summary>
        /// Injected contructor
        /// </summary>
        /// <param name="vulcanHandler"></param>
        /// <param name="localizationService"></param>
        /// <param name="siteDefintionResolver"></param>
        /// <param name="contentRepository"></param>
        /// <param name="contentTypeRepository"></param>
        /// <param name="uiDescriptorRegistry"></param>
        public VulcanPageSearchProvider(
            IVulcanHandler vulcanHandler,
            LocalizationService localizationService,
            ISiteDefinitionResolver siteDefintionResolver,
            IContentRepository contentRepository,
            IContentTypeRepository contentTypeRepository,
            UIDescriptorRegistry uiDescriptorRegistry
        )
          : base(vulcanHandler, contentRepository, contentTypeRepository, localizationService, uiDescriptorRegistry, siteDefintionResolver)
        {

        }

        /// <summary>
        /// Area that the provider maps to, used for spotlight searching
        /// </summary>
        /// <value>
        /// CMS
        /// </value>
        public override string Area => "CMS/pages";

        /// <summary>
        /// Gets the CMS page category.
        /// </summary>
        public override string Category => _LocalizationService.GetString("/vulcan/searchprovider/pages/name");

        /// <summary>
        /// Gets the name of the localization page type.
        /// </summary>
        protected override string ToolTipContentTypeNameResourceKey => "pagetype";

        /// <summary>
        /// Gets the page localization path.
        /// </summary>
        protected override string ToolTipResourceKeyBase => "/shell/cms/search/pages/tooltip";

        /// <summary>
        /// Gets the icon CSS class for pages.
        /// </summary>
        protected override string IconCssClass(IContent pageData) => "epi-resourceIcon epi-resourceIcon-page";
    }
}