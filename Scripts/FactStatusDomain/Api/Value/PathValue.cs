using FactStatus.Domain.Internal.Rule;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Api.Value {
    public class PathValue {

        private PathTypeEnum _pathTypeEnum;
        public string Path { get; }

        /// <summary>
        /// パスのバリデーションチェック
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

        /// <summary>
        /// Rootパスで生成するコンストラクタ
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static PathValue PathIsRoot(string path) {
            // 空チェック
            Validation.NullOfString(path);

            // ルート or フォルダ or ファイルチェック
            ValidatePath(path, PathTypeEnum.Root);

            return new PathValue(path,PathTypeEnum.Root);
        }

        /// <summary>
        /// Directoryパスで生成するコンストラクタ
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static PathValue PathIsDirectory(string path) {
            // 空チェック
            Validation.NullOfString(path);

            // ルート or フォルダ or ファイルチェック
            ValidatePath(path, PathTypeEnum.Directory);

            return new PathValue(path,PathTypeEnum.Directory);
        }

        /// <summary>
        /// Fileパスで生成するコンストラクタ
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static PathValue PathIsFile(string path) {
            // 空チェック
            Validation.NullOfString(path);

            // ルート or フォルダ or ファイルチェック
            ValidatePath(path, PathTypeEnum.File);

            return new PathValue(path,PathTypeEnum.File);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pathTypeEnum"></param>
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
