﻿using System;

namespace CSMath
{
	public static class VectorExtensions
	{
		/// <summary>
		/// Angle between two <see cref="IVector"/>.
		/// </summary>
		/// <param name="v">The first <see cref="IVector" />.</param>
		/// <param name="u">The second <see cref="IVector" />.</param>
		public static double Angle<T>(this T v, T u)
			where T : IVector, new()
		{
			if (v.IsZero() || u.IsZero())
				throw new InvalidOperationException("Cannot calculate the angle between two vectors, if one is zero.");

			return Math.Acos(v.Dot(u) / (v.GetLength() * u.GetLength()));
		}

		/// <summary>
		/// Returns true if the magnitude of the <see cref="IVector"/> is zero.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="v"></param>
		/// <returns></returns>
		public static bool IsZero<T>(this T v)
			where T : IVector, new()
		{
			return v.GetLength() == 0;
		}

		/// <summary>
		/// Distance between two <see cref="IVector"/>.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="v"></param>
		/// <param name="u"></param>
		/// <returns></returns>
		public static double DistanceFrom<T>(this T v, T u)
			where T : IVector, new()
		{
			return Subtract(v, u).GetLength();
		}

		/// <summary>
		/// Returns the length of the vector.
		/// </summary>
		/// <returns>The vector's length.</returns>
		public static double GetLength<T>(this T vector)
			where T : IVector
		{
			double length = 0;

			for (uint i = 0; i < vector.Dimension; i++)
			{
				length += Math.Pow(vector[i], 2);
			}

			return Math.Sqrt(length);
		}

		/// <summary>
		/// Returns a vector with the same direction as the given vector, but with a length of 1.
		/// </summary>
		/// <param name="vector">The vector to normalize.</param>
		/// <returns>The normalized vector.</returns>
		public static T Normalize<T>(this T vector)
			where T : IVector, new()
		{
			double length = vector.GetLength();
			T result = new T();

			for (uint i = 0; i < result.Dimension; i++)
			{
				result[i] = vector[i] / length;
			}

			return result;
		}

		/// <summary>
		/// Returns the dot product of two vectors.
		/// </summary>
		/// <param name="left">The first vector.</param>
		/// <param name="right">The second vector.</param>
		/// <returns>The dot product.</returns>
		public static double Dot<T>(this T left, T right)
			where T : IVector
		{
			double result = 0;
			for (uint i = 0; i < left.Dimension; ++i)
			{
				result += left[i] * right[i];
			}

			return result;
		}

		public static double Cross<T>(this T left, T right)
			where T : IVector
		{
			var components1 = left.GetComponents();
			var components2 = right.GetComponents();
			double result = 0;



			return result;
		}

		/// <summary>
		/// Returns a boolean indicating whether the two given vectors are parallel.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="left">The first vector.</param>
		/// <param name="right">The second vector.</param>
		/// <returns></returns>
		public static bool IsParallel<T>(this T left, T right)
			where T : IVector
		{
			return Cross<T>(left, right) == 0;
		}

		/// <summary>
		/// Returns a boolean indicating whether the two given vectors are perpendicular.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="left">The first vector.</param>
		/// <param name="right">The second vector.</param>
		/// <returns></returns>
		public static bool IsPerpendicular<T>(this T left, T right)
			where T : IVector
		{
			return Dot<T>(left, right) == 0;
		}

		/// <summary>
		/// Returns a boolean indicating whether the two given vectors are equal.
		/// </summary>
		/// <param name="left">The first vector to compare.</param>
		/// <param name="right">The second vector to compare.</param>
		/// <returns>True if the vectors are equal; False otherwise.</returns>
		public static bool IsEqual<T>(this T left, T right)
			where T : IVector
		{
			var components1 = left.GetComponents();
			var components2 = right.GetComponents();

			for (int i = 0; i < components1.Length; i++)
			{
				if (components1[i] != components2[i])
					return false;
			}

			return true;
		}

		/// <summary>
		/// Returns a boolean indicating whether the two given vectors are equal.
		/// </summary>
		/// <param name="left">The first vector to compare.</param>
		/// <param name="right">The second vector to compare.</param>
		/// <param name="ndecimals">Number of decimals digits to be set as precision.</param>
		/// <returns>True if the vectors are equal; False otherwise.</returns>
		public static bool IsEqual<T>(this T left, T right, int ndecimals)
			where T : IVector
		{
			var components1 = left.GetComponents();
			var components2 = right.GetComponents();

			for (int i = 0; i < components1.Length; i++)
			{
				if (Math.Round(components1[i], ndecimals) != Math.Round(components2[i], ndecimals))
					return false;
			}

			return true;
		}

		/// <summary>
		/// Adds two vectors together.
		/// </summary>
		/// <param name="left">The first source vector.</param>
		/// <param name="right">The second source vector.</param>
		/// <returns>The summed vector.</returns>
		public static T Add<T>(this T left, T right)
			where T : IVector, new()
		{
			return applyFunctionByComponentIndex(left, right, (o, x) => o + x);
		}

		/// <summary>
		/// Subtracts the second vector from the first.
		/// </summary>
		/// <param name="left">The first source vector.</param>
		/// <param name="right">The second source vector.</param>
		/// <returns>The difference vector.</returns>
		public static T Subtract<T>(this T left, T right)
			where T : IVector, new()
		{
			return applyFunctionByComponentIndex(left, right, (o, x) => o - x);
		}

		/// <summary>
		/// Multiplies two vectors together.
		/// </summary>
		/// <param name="left">The first source vector.</param>
		/// <param name="right">The second source vector.</param>
		/// <returns>The product vector.</returns>
		public static T Multiply<T>(this T left, T right)
			where T : IVector, new()
		{
			return applyFunctionByComponentIndex(left, right, (o, x) => o * x);
		}

		/// <summary>
		/// Multiplies a vector with an scalar.
		/// </summary>
		/// <param name="left">The first source vector.</param>
		/// <param name="right">The second source vector.</param>
		/// <returns>The product vector.</returns>
		public static T Multiply<T>(this T left, double scalar)
			where T : IVector, new()
		{
			return applyFunctionByScalar(left, scalar, (o, x) => o * x);
		}

		/// <summary>
		/// Divides the first vector by the second.
		/// </summary>
		/// <param name="left">The first source vector.</param>
		/// <param name="right">The second source vector.</param>
		/// <returns>The vector resulting from the division.</returns>
		public static T Divide<T>(this T left, T right)
			where T : IVector, new()
		{
			return applyFunctionByComponentIndex(left, right, (o, x) => o / x);
		}

		/// <summary>
		/// Divides a vector with an scalar.
		/// </summary>
		public static T Divide<T>(this T left, double scalar)
			where T : IVector, new()
		{
			return applyFunctionByScalar(left, scalar, (o, x) => o / x);
		}

		/// <summary>
		/// Round the vector components
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="vector"></param>
		/// <returns></returns>
		public static T Round<T>(this T vector)
			where T : IVector, new()
		{
			T result = new T();

			for (uint i = 0; i < result.Dimension; i++)
			{
				result[i] = Math.Round(vector[i]);
			}

			return result;
		}

		/// <summary>
		/// Round the vector components
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="vector"></param>
		/// <param name="digits">The number of fractional digits in the return value</param>
		/// <returns></returns>
		public static T Round<T>(this T vector, int digits)
			where T : IVector, new()
		{
			T result = new T();

			for (uint i = 0; i < result.Dimension; i++)
			{
				result[i] = Math.Round(vector[i], digits);
			}

			return result;
		}

		// Applies a function in all the components of a vector by order
		private static T applyFunctionByComponentIndex<T>(this T left, T right, Func<double, double, double> op)
			where T : IVector, new()
		{
			T result = new T();

			for (uint i = 0; i < left.Dimension; i++)
			{
				result[i] = op(left[i], right[i]);
			}

			return result;
		}

		private static T applyFunctionByScalar<T>(this T v, double scalar, Func<double, double, double> op)
			where T : IVector, new()
		{
			T result = new T();

			for (uint i = 0; i < v.Dimension; i++)
			{
				result[i] = op(v[i], scalar);
			}

			return result;
		}
	}
}
