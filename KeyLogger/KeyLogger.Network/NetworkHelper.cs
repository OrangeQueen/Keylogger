using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace KeyLogger.Network
{
    public static class NetworkHelper
    {
        public static bool ValidIPv4(string ip)
        {
            IPAddress address;

            if (IPAddress.TryParse(ip, out address))
            {
                switch (address.AddressFamily)
                {
                    case AddressFamily.InterNetwork:
                        return true;
                        //break;
                    default:
                        return false;
                }
            }

            return false;
        }

        public static bool ValidIPv6(string ip)
        {
            IPAddress address;
            if (IPAddress.TryParse(ip, out address))
            {
                switch (address.AddressFamily)
                {
                    case AddressFamily.InterNetworkV6:
                        return false;
                        //break;
                    default:
                        return false;
                }
            }

            return false;
        }

        public static List<string> GetHostAdapters()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            return (nics.Where(
                adapter =>
                    adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    adapter.NetworkInterfaceType != NetworkInterfaceType.Unknown)
                .Where(adapter => adapter.Supports(NetworkInterfaceComponent.IPv4))
                .Where(adapter => adapter.OperationalStatus == OperationalStatus.Up)
                .Select(adapter => new {adapter, properties = adapter.GetIPProperties()})
                .SelectMany(@t => @t.properties.UnicastAddresses, (@t, unicastAddress) => new {@t, unicastAddress})
                .Where(
                    @t =>
                        @t.unicastAddress != null && @t.unicastAddress.Address != null &&
                        @t.unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
                .Select(@t => @t.@t.adapter.Name)).ToList();


            //var namelist = new List<string>();

            //var nics = NetworkInterface.GetAllNetworkInterfaces();

            //foreach (var adapter in nics)
            //{
            //    if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback || adapter.NetworkInterfaceType == NetworkInterfaceType.Unknown)
            //        continue;
            //    if (!adapter.Supports(NetworkInterfaceComponent.IPv4))
            //        continue;
            //    if (adapter.OperationalStatus != OperationalStatus.Up)
            //        continue;

            //    var properties = adapter.GetIPProperties();
            //    foreach (var unicastAddress in properties.UnicastAddresses)
            //    {
            //        if (unicastAddress != null && unicastAddress.Address != null && unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
            //        {
            //            namelist.Add(adapter.Name);
            //        }
            //    }
            //}

            //return namelist;
        }


        public static List<string> GetHostIpAdresses()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            return (nics.Where(
                adapter =>
                    adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    adapter.NetworkInterfaceType != NetworkInterfaceType.Unknown)
                .Where(adapter => adapter.Supports(NetworkInterfaceComponent.IPv4))
                .Where(adapter => adapter.OperationalStatus == OperationalStatus.Up)
                .Select(adapter => adapter.GetIPProperties())
                .SelectMany(properties => properties.UnicastAddresses,
                    (properties, unicastAddress) => new {properties, unicastAddress})
                .Where(
                    @t =>
                        @t.unicastAddress != null && @t.unicastAddress.Address != null &&
                        @t.unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
                .Select(@t => @t.unicastAddress.Address.ToString())).ToList();

            //foreach (var adapter in nics)
            //{
            //    if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback || adapter.NetworkInterfaceType == NetworkInterfaceType.Unknown)
            //        continue;
            //    if (!adapter.Supports(NetworkInterfaceComponent.IPv4))
            //        continue;
            //    if (adapter.OperationalStatus != OperationalStatus.Up)
            //        continue;

            //    var properties = adapter.GetIPProperties();
            //    foreach (var unicastAddress in properties.UnicastAddresses)
            //    {
            //        if (unicastAddress != null && unicastAddress.Address != null && unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
            //        {
            //            iplist.Add(unicastAddress.Address.ToString());
            //        }
            //    }
            //}

            //return iplist;
        }
    }
}