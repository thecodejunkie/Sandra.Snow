﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandra.Snow.PreCompiler.StaticFileProcessors
{
    using System.IO;
    using Nancy.Testing;

    class SitemapProcessor : BaseProcessor
    {
        public override string ProcessorName
        {
            get { return "sitemap"; }
        }

        public override void Process(SnowyData snowyData, SnowSettings settings)
        {
            var result = snowyData.Browser.Post("/sitemap");

            var outputFolder = snowyData.Settings.Output;

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            File.WriteAllText(Path.Combine(outputFolder, snowyData.File.File), result.Body.AsString());
        }
    }
}
