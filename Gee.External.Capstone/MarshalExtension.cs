using System;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone;

/// <summary>
///     Marshal Extension.
/// </summary>
internal static class MarshalExtension {
    /// <summary>
    ///     Allocate Memory For a Structure.
    /// </summary>
    /// <typeparam name="T">
    ///     The structure's type.
    /// </typeparam>
    /// <returns>
    ///     A pointer to the allocated memory.
    /// </returns>
    internal static IntPtr AllocHGlobal<T>() {
        var nType = Marshal.SizeOf<T>();
        var pType = Marshal.AllocHGlobal(nType);

        return pType;
    }

    /// <summary>
    ///     Allocate Memory For a Structure.
    /// </summary>
    /// <param name="size">
    ///     The collection's size.
    /// </param>
    /// <typeparam name="T">
    ///     The structure's type.
    /// </typeparam>
    /// <returns>
    ///     A pointer to the allocated memory.
    /// </returns>
    internal static IntPtr AllocHGlobal<T>(int size) {
        var nType = Marshal.SizeOf<T>() * size;
        var pType = Marshal.AllocHGlobal(nType);

        return pType;
    }

    /// <summary>
    ///     Marshal a Pointer to a Structure and Free Memory.
    /// </summary>
    /// <typeparam name="T">
    ///     The destination structure's type.
    /// </typeparam>
    /// <param name="p">
    ///     The pointer to marshal.
    /// </param>
    /// <returns>
    ///     The destination structure.
    /// </returns>
    internal static T FreePtrToStructure<T>(IntPtr p) {
        var @struct = Marshal.PtrToStructure<T>(p);
        Marshal.FreeHGlobal(p);

        return @struct;
    }

    /// <summary>
    ///     Marshal a Pointer to a Collection of Structures.
    /// </summary>
    /// <typeparam name="T">
    ///     The collection's type.
    /// </typeparam>
    /// <param name="p">
    ///     A pointer to a collection. The pointer should be initialized to the collection's starting address.
    /// </param>
    /// <param name="size">
    ///     The collection's size.
    /// </param>
    /// <returns>
    ///     The destination collection.
    /// </returns>
    internal static T[] PtrToStructure<T>(IntPtr p, int size) {
        var array = new T[size];
        var index = p;
        for (var i = 0; i < size; i++) {
            var element = Marshal.PtrToStructure<T>(index);
            array[i] = element;

            index += Marshal.SizeOf<T>();
        }

        return array;
    }
}