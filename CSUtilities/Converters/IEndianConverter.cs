﻿namespace CSUtilities.Converters
{
	/// <summary>Represents a endian bit converter.</summary>
	internal interface IEndianConverter
	{
		/// <summary>Returns the specified value as an array of bytes.</summary>
		byte[] GetBytes(char value);
		/// <summary>Returns the specified value as an array of bytes.</summary>
		byte[] GetBytes(short value);
		/// <summary>Returns the specified value as an array of bytes.</summary>
		byte[] GetBytes(ushort value);
		/// <summary>Returns the specified value as an array of bytes.</summary>
		byte[] GetBytes(int value);
		/// <summary>Returns the specified value as an array of bytes.</summary>
		byte[] GetBytes(uint value);
		/// <summary>Returns the specified value as an array of bytes.</summary>
		byte[] GetBytes(long value);
		/// <summary>Returns the specified value as an array of bytes.</summary>
		byte[] GetBytes(ulong value);
		/// <summary>Returns the specified value as an array of bytes.</summary>
		byte[] GetBytes(double value);
		/// <summary>Returns the specified value as an array of bytes.</summary>
		byte[] GetBytes(float value);
		/// <summary>
		/// Converts the specified bytes to a <see cref="System.Char" />.
		/// </summary>
		char ToChar(byte[] arr);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.Int16" />.
		/// </summary>
		short ToInt16(byte[] arr);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.UInt16" />.
		/// </summary>
		ushort ToUInt16(byte[] arr);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.Int32" />.
		/// </summary>
		int ToInt32(byte[] arr);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.UInt32" />.
		/// </summary>
		uint ToUInt32(byte[] arr);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.Int64" />.
		/// </summary>
		long ToInt64(byte[] arr);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.UInt64" />.
		/// </summary>
		ulong ToUInt64(byte[] arr);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.Double" />.
		/// </summary>
		double ToDouble(byte[] arr);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.Single" />.
		/// </summary>
		float ToSingle(byte[] arr);
		/// <summary>
		/// Converts the specified bytes to a <see cref="System.Char" />.
		/// </summary>
		char ToChar(byte[] arr, int length);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.Int16" />.
		/// </summary>
		short ToInt16(byte[] arr, int length);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.UInt16" />.
		/// </summary>
		ushort ToUInt16(byte[] arr, int length);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.Int32" />.
		/// </summary>
		int ToInt32(byte[] arr, int length);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.UInt32" />.
		/// </summary>
		uint ToUInt32(byte[] arr, int length);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.Int64" />.
		/// </summary>
		long ToInt64(byte[] arr, int length);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.UInt64" />.
		/// </summary>
		ulong ToUInt64(byte[] arr, int length);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.Double" />.
		/// </summary>
		double ToDouble(byte[] arr, int length);
		/// <summary>
		/// Converts the specified bytes to an <see cref="System.Single" />.
		/// </summary>
		float ToSingle(byte[] arr, int length);
	}
}