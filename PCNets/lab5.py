import pandas as pd


def prefix_to_mask(_prefix):
    mask_bin = "1" * _prefix + "0" * (32 - _prefix)
    mask_octets = [int(mask_bin[i:i + 8], 2) for i in range(0, 32, 8)]
    return mask_octets


def ip_to_bin(_ip):
    return ''.join(f"{int(octet):08b}" for octet in _ip.split('.'))


def bin_to_ip(_bin_str):
    octets = [str(int(_bin_str[i:i + 8], 2)) for i in range(0, 32, 8)]
    return '.'.join(octets)


def calculate_network_broadcast(_ip, _prefix):
    # Получаем маску подсети
    mask = prefix_to_mask(_prefix)
    mask_bin = ''.join(f"{octet:08b}" for octet in mask)

    # Преобразуем IP в двоичный формат
    ip_bin = ip_to_bin(_ip)

    # Рассчитываем сетевой адрес (побитовое И)
    network_bin = ''.join("1" if ip_bin[i] == "1" and mask_bin[i] == "1" else "0" for i in range(32))

    # Рассчитываем широковещательный адрес (побитовое ИЛИ)
    broadcast_bin = ''.join("1" if mask_bin[i] == "0" else ip_bin[i] for i in range(32))

    return bin_to_ip(network_bin), bin_to_ip(broadcast_bin)


def calculate_total_hosts(_prefix):
    _host_bits = 32 - _prefix
    return (2 ** _host_bits) - 2 if _host_bits > 0 else 0


inputs = [
    ("172.30.239.145", 18),
    ("192.168.100.25", 28),
    ("172.30.10.130", 30),
    ("10.1.113.75", 19),
    ("198.133.219.250", 24),
    ("128.107.14.191", 22),
    ("172.16.104.99", 27)
]

results = []
for ip, prefix in inputs:
    network_address, broadcast_address = calculate_network_broadcast(ip, prefix)
    total_hosts = calculate_total_hosts(prefix)
    host_bits = 32 - prefix
    results.append((ip, network_address, broadcast_address, host_bits, total_hosts))

df = pd.DataFrame(results, columns=[
    "IPv4 Address/Prefix",
    "Network Address",
    "Broadcast Address",
    "Host Bits",
    "Total Hosts"
])

print(df)
