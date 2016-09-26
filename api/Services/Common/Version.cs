using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
	public class Version
	{
		// Summary:
		//     Initializes a new instance of the System.Version class.
		public Version() { }
		//
		// Summary:
		//     Initializes a new instance of the System.Version class using the specified
		//     string.
		//
		// Parameters:
		//   version:
		//     A string containing the major, minor, build, and revision numbers, where
		//     each number is delimited with a period character ('.').
		//
		// Exceptions:
		//   System.ArgumentException:
		//     version has fewer than two components or more than four components.
		//
		//   System.ArgumentNullException:
		//     version is null.
		//
		//   System.ArgumentOutOfRangeException:
		//     A major, minor, build, or revision component is less than zero.
		//
		//   System.FormatException:
		//     At least one component of version does not parse to an integer.
		//
		//   System.OverflowException:
		//     At least one component of version represents a number greater than System.Int32.MaxValue.
		public Version(string version)
		{
			Version v = Parse(version);
			major = v.major;
			minor = v.minor;
			build = v.build;
			revision = v.revision;
			minorRevision = v.minorRevision;
		}
		//
		// Summary:
		//     Initializes a new instance of the System.Version class using the specified
		//     major and minor values.
		//
		// Parameters:
		//   major:
		//     The major version number.
		//
		//   minor:
		//     The minor version number.
		//
		// Exceptions:
		//   System.ArgumentOutOfRangeException:
		//     major or minor is less than zero.
		public Version(int major, int minor)
		{
			this.major = major;
			this.minor = minor;
		}
		//
		// Summary:
		//     Initializes a new instance of the System.Version class using the specified
		//     major, minor, and build values.
		//
		// Parameters:
		//   major:
		//     The major version number.
		//
		//   minor:
		//     The minor version number.
		//
		//   build:
		//     The build number.
		//
		// Exceptions:
		//   System.ArgumentOutOfRangeException:
		//     major, minor, or build is less than zero.
		public Version(int major, int minor, int build)
		{
			this.major = major;
			this.minor = minor;
			this.build = build;
		}
		//
		// Summary:
		//     Initializes a new instance of the System.Version class with the specified
		//     major, minor, build, and revision numbers.
		//
		// Parameters:
		//   major:
		//     The major version number.
		//
		//   minor:
		//     The minor version number.
		//
		//   build:
		//     The build number.
		//
		//   revision:
		//     The revision number.
		//
		// Exceptions:
		//   System.ArgumentOutOfRangeException:
		//     major, minor, build, or revision is less than zero.
		public Version(int major, int minor, int build, int revision)
		{
			this.major = major;
			this.minor = minor;
			this.build = build;
			this.revision = revision;
		}
		//
		// Summary:
		//     Initializes a new instance of the System.Version class with the specified
		//     major, minor, build, and revision numbers.
		//
		// Parameters:
		//   major:
		//     The major version number.
		//
		//   minor:
		//     The minor version number.
		//
		//   build:
		//     The build number.
		//
		//   revision:
		//     The revision number.
		//
		//   rminorRevision:
		//     The revision number.
		//
		//
		// Exceptions:
		//   System.ArgumentOutOfRangeException:
		//     major, minor, build, evision, or minorRevision is less than zero.
		public Version(int major, int minor, int build, int revision, int minorRevision)
		{
			this.major = major;
			this.minor = minor;
			this.build = build;
			this.revision = revision;
			this.minorRevision = minorRevision;
		}

		private int major = -1;
		private int minor = -1;
		private int build = -1;
		private int revision = -1;
		private int minorRevision = -1;

		// Summary:
		//     Determines whether two specified System.Version objects are not equal.
		//
		// Parameters:
		//   v1:
		//     The first System.Version object.
		//
		//   v2:
		//     The second System.Version object.
		//
		// Returns:
		//     true if v1 does not equal v2; otherwise, false.
		public static bool operator !=(Version v1, Version v2)
		{
			if (v1.Major == v2.Major)
				return false;

			if (v1.Minor == v2.Minor && v1.Minor != -1 && v2.Minor != -1)
				return false;

			if (v1.Build == v2.Build && v1.Build != -1 && v2.Build != -1)
				return false;

			if (v1.Revision == v2.Revision && v1.Revision != -1 && v2.Revision != -1)
				return false;

			if (v1.MinorRevision == v2.MinorRevision && v1.MinorRevision != -1 && v2.MinorRevision != -1)
				return false;

			return true;
		}

		//
		// Summary:
		//     Determines whether the first specified System.Version object is less than
		//     or equal to the second System.Version object.
		//
		// Parameters:
		//   v1:
		//     The first System.Version object.
		//
		//   v2:
		//     The second System.Version object.
		//
		// Returns:
		//     true if v1 is less than or equal to v2; otherwise, false.
		//
		// Exceptions:
		//   System.ArgumentNullException:
		//     v1 is null.
		public static bool operator <=(Version v1, Version v2)
		{
			if (v1.Major > v2.Major)
				return false;

			if (v1.Minor > v2.Minor && v1.Minor != -1 && v2.Minor != -1)
				return false;

			if (v1.Build > v2.Build && v1.Build != -1 && v2.Build != -1)
				return false;

			if (v1.Revision > v2.Revision && v1.Revision != -1 && v2.Revision != -1)
				return false;

			if (v1.MinorRevision > v2.MinorRevision && v1.MinorRevision != -1 && v2.MinorRevision != -1)
				return false;

			return true;
		}

		//
		// Summary:
		//     Determines whether two specified System.Version objects are equal.
		//
		// Parameters:
		//   v1:
		//     The first System.Version object.
		//
		//   v2:
		//     The second System.Version object.
		//
		// Returns:
		//     true if v1 equals v2; otherwise, false.
		public static bool operator ==(Version v1, Version v2)
		{
			if (v1.Major != v2.Major)
				return false;

			if (v1.Minor != v2.Minor && v1.Minor != -1 && v2.Minor != -1)
				return false;

			if (v1.Build != v2.Build && v1.Build != -1 && v2.Build != -1)
				return false;

			if (v1.Revision != v2.Revision && v1.Revision != -1 && v2.Revision != -1)
				return false;

			if (v1.MinorRevision != v2.MinorRevision && v1.MinorRevision != -1 && v2.MinorRevision != -1)
				return false;

			return true;
		}

		//
		// Summary:
		//     Determines whether the first specified System.Version object is greater than
		//     or equal to the second specified System.Version object.
		//
		// Parameters:
		//   v1:
		//     The first System.Version object.
		//
		//   v2:
		//     The second System.Version object.
		//
		// Returns:
		//     true if v1 is greater than or equal to v2; otherwise, false.
		public static bool operator >=(Version v1, Version v2)
		{
			if (v1.Major < v2.Major)
				return false;

			if (v1.Minor < v2.Minor && v1.Minor != -1 && v2.Minor != -1)
				return false;

			if (v1.Build < v2.Build && v1.Build != -1 && v2.Build != -1)
				return false;

			if (v1.Revision < v2.Revision && v1.Revision != -1 && v2.Revision != -1)
				return false;

			if (v1.MinorRevision < v2.MinorRevision && v1.MinorRevision != -1 && v2.MinorRevision != -1)
				return false;

			return true;
		}

		//
		// Summary:
		//     Gets the value of the major component of the version number for the current
		//     System.Version object.
		//
		// Returns:
		//     The major version number.
		public int Major { get { return major; } }
		//
		// Summary:
		//     Gets the value of the minor component of the version number for the current
		//     System.Version object.
		//
		// Returns:
		//     The minor version number.
		public int Minor { get { return minor; } }
		//
		// Summary:
		//     Gets the low 16 bits of the revision number.
		//
		// Returns:
		//     A 16-bit signed integer.
		// Summary:
		//     Gets the value of the build component of the version number for the current
		//     System.Version object.
		//
		// Returns:
		//     The build number, or -1 if the build number is undefined.
		public int Build { get { return build; } }
		//
		// Summary:
		//     Gets the value of the revision component of the version number for the current
		//     System.Version object.
		//
		// Returns:
		//     The revision number, or -1 if the revision number is undefined.
		public int Revision { get { return revision; } }
		//
		// Summary:
		//     Gets the value of the revision component of the version number for the current
		//     System.Version object.
		//
		// Returns:
		//     The minor revision number, or -1 if the revision number is undefined.
		public int MinorRevision { get { return minorRevision; } }

		//
		// Summary:
		//     Converts the string representation of a version number to an equivalent System.Version
		//     object.
		//
		// Parameters:
		//   input:
		//     A string that contains a version number to convert.
		//
		// Returns:
		//     An object that is equivalent to the version number specified in the input
		//     parameter.
		//
		// Exceptions:
		//   System.ArgumentNullException:
		//     input is null.
		//
		//   System.ArgumentException:
		//     input has fewer than two or more than four version components.
		//
		//   System.ArgumentOutOfRangeException:
		//     At least one component in input is less than zero.
		//
		//   System.FormatException:
		//     At least one component in input is not an integer.
		//
		//   System.OverflowException:
		//     At least one component in input represents a number that is greater than
		//     System.Int32.MaxValue.
		public static Version Parse(string input)
		{
			string[] sa = input.Split('.');
			Version version = new Version();
			int v, i = 0;

			foreach (string s in sa)
			{
				if (int.TryParse(s, out v))
				{
					switch (i)
					{
						case 0:
							version.major = v;
							break;
						case 1:
							version.minor = v;
							break;
						case 2:
							version.build = v;
							break;
						case 3:
							version.revision = v;
							break;
						case 4:
							version.minorRevision = v;
							break;
					}
				}
				else
				{
					return null;
				}

				i++;
			}

			return version;
		}

		//
		// Summary:
		//     Converts the value of the current System.Version object to its equivalent
		//     System.String representation.
		//
		// Returns:
		//     The System.String representation of the values of the major, minor, build,
		//     and revision components of the current System.Version object, as depicted
		//     in the following format. Each component is separated by a period character
		//     ('.'). Square brackets ('[' and ']') indicate a component that will not appear
		//     in the return value if the component is not defined: major.minor[.build[.revision]]
		//     For example, if you create a System.Version object using the constructor
		//     Version(1,1), the returned string is "1.1". If you create a System.Version
		//     object using the constructor Version(1,3,4,2), the returned string is "1.3.4.2".
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}.{3}.{4}", major, minor, build, revision, minorRevision);
		}

		//
		// Summary:
		//     Converts the value of the current System.Version object to its equivalent
		//     System.String representation. A specified count indicates the number of components
		//     to return.
		//
		// Parameters:
		//   fieldCount:
		//     The number of components to return. The fieldCount ranges from 0 to 4.
		//
		// Returns:
		//     The System.String representation of the values of the major, minor, build,
		//     and revision components of the current System.Version object, each separated
		//     by a period character ('.'). The fieldCount parameter determines how many
		//     components are returned.fieldCount Return Value 0 An empty string (""). 1
		//     major 2 major.minor 3 major.minor.build 4 major.minor.build.revision For
		//     example, if you create System.Version object using the constructor Version(1,3,5),
		//     ToString(2) returns "1.3" and ToString(4) throws an exception.
		//
		// Exceptions:
		//   System.ArgumentException:
		//     fieldCount is less than 0, or more than 4.-or- fieldCount is more than the
		//     number of components defined in the current System.Version object.
		public string ToString(int fieldCount)
		{
			string version = string.Empty;

			if (fieldCount >= 1)
				version = major.ToString();
			if (fieldCount >= 2)
				version += string.Format(".{0}", minor);
			if (fieldCount >= 3)
				version += string.Format(".{0}", build);
			if (fieldCount >= 4)
				version += string.Format(".{0}", revision);
			if (fieldCount >= 5)
				version += string.Format(".{0}", minorRevision);

			return version;
		}

		//
		// Summary:
		//     Tries to convert the string representation of a version number to an equivalent
		//     System.Version object, and returns a value that indicates whether the conversion
		//     succeeded.
		//
		// Parameters:
		//   input:
		//     A string that contains a version number to convert.
		//
		//   result:
		//     When this method returns, contains the System.Version equivalent of the number
		//     that is contained in input, if the conversion succeeded, or a System.Version
		//     object whose major and minor version numbers are 0 if the conversion failed.
		//
		// Returns:
		//     true if the input parameter was converted successfully; otherwise, false.
		public static bool TryParse(string input, out Version result)
		{
			string[] sa = input.Split('.');
			result = new Version();

			foreach (string s in sa)
			{
				int v, i = 0;

				if (int.TryParse(s, out v))
				{
					switch (i)
					{
						case 0:
							result.major = v;
							break;
						case 1:
							result.minor = v;
							break;
						case 2:
							result.build = v;
							break;
						case 3:
							result.revision = v;
							break;
						case 4:
							result.minorRevision = v;
							break;
					}

					i++;
				}
				else
				{
					return false;
				}
			}

			return true;
		}
	}
}
