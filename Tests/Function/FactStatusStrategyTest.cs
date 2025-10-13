using FactStatusTool.Scripts.Function;
using FactStatusTool.Scripts.Variable;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FactStatusTool.Tests.Function {
    public class FactStatusStrategyTest(ITestOutputHelper output) {
        private readonly ITestOutputHelper output = output;

        [Fact]
        public void LoadJsonByRelationalTest() {
            var documentStrategy = new FactStatusStrategy(new JsonRepository(), new MarkdownRepository());
            FacutStatusConfig documentConfig = documentStrategy.LoadJsonByRelational("D:/Action/__CoreTemplateIDCM/Document/RelationalData.json");

            Assert.NotNull(documentConfig);
            Assert.NotNull(documentConfig.SubjectConfigList);
            Assert.NotEmpty(documentConfig.SubjectConfigList);

            FileInfo fileInfo = new ("D:/Action/__CoreTemplateIDCM/Document/RelationalSaveTest.json");
            if (fileInfo.Exists) {
                fileInfo.Delete();
            }

            documentStrategy.SaveJsonByRelational(fileInfo.ToString(), documentConfig);

            //foreach (ProjectDto projectDto in documentConfig.ProjectConfigList) {
            //    output.WriteLine($"Project_Id: {projectDto.Id}");
            //    output.WriteLine($"Project_Path: {projectDto.PathName}");
            //    output.WriteLine($"Project_Title: {projectDto.Title}");
            //    output.WriteLine($"Project_Description: {projectDto.Description}");
            //}

            //foreach (TodoDto todoDto in relationalDataDto.Todos) {
            //    output.WriteLine($"Todo_ParentId: {todoDto.ParentId}");
            //    output.WriteLine($"Todo_Id: {todoDto.Id}");
            //    output.WriteLine($"Todo_Path: {todoDto.PathName}");
            //    output.WriteLine($"Todo_Title: {todoDto.Title}");
            //    output.WriteLine($"Todo_Description: {todoDto.Description}");
            //}

            //foreach (ValidateDto validateDto in relationalDataDto.Validates) {
            //    output.WriteLine($"Validate_ParentId: {validateDto.ParentId}");
            //    output.WriteLine($"Validate_Id: {validateDto.Id}");
            //    output.WriteLine($"Validate_Path: {validateDto.PathName}");
            //    output.WriteLine($"Validate_Title: {validateDto.Title}");
            //    output.WriteLine($"Validate_Description: {validateDto.Description}");
            //}

            //foreach (ResultDto resultDto in relationalDataDto.Results) {

            //}

            //foreach (RecordDto recordDto in relationalDataDto.Records) {

            //}

            //foreach (ProcessDto processDto in relationalDataDto.Process) {

            //}

            //foreach (SchemaDto schemaDto in relationalDataDto.Schemas) {

            //}

            //foreach (ArgumentDto argumentDto in relationalDataDto.Arguments) {

            //}

            //foreach (StepDto stepDto in relationalDataDto.Steps) {

            //}
        }
    }
}
