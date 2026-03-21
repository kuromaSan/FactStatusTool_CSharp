using FactStatus.Domain.Rule;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Value {
    public class PathValue {

        private PathTypeEnum _pathTypeEnum;
        public string Path { get; private set; }

        public string GetPath() {
            return Path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void Change(string path) {
            // 空チェックどフォルダ階層チェック
            Validation.NullOfString(path);
            ValidatePath(path,_pathTypeEnum);
            Path = path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pathTypeEnum"></param>
        private static void ValidatePath(string path, PathTypeEnum pathTypeEnum) {
            switch (pathTypeEnum) {
                case PathTypeEnum.Root:
                    Validation.RootValue(path);
                    break;
                case PathTypeEnum.Directory:
                    Validation.DirectoryValue(path);
                    break;
                case PathTypeEnum.File:
                    Validation.FileValue(path);
                    break;
            }
        }

        public PathValue(string path, PathTypeEnum pathTypeEnum) {
            // 空チェック
            Validation.NullOfString(path);

            // ルート or フォルダ or ファイルチェック
            ValidatePath(path,pathTypeEnum);

            Path = path;
            _pathTypeEnum = pathTypeEnum;
        }
    }
}
