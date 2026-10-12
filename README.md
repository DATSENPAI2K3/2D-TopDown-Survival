# 2D Survival Zone

## Giới thiệu

Đây là dự án game 2D thể loại Survival Roguelike được phát triển bằng Unity và C#.

Người chơi phải chiến đấu với các đợt quái vật liên tục xuất hiện, nâng cấp sức mạnh nhân vật và cố gắng sống sót càng lâu càng tốt.

## Tính năng đã thực hiện

* Hệ thống bản đồ vô hạn (Infinite Map)
* Enemy AI tự động tìm và di chuyển theo người chơi
* Hệ thống vũ khí
* Hệ thống nâng cấp nhân vật
* Hệ thống máu và sát thương
* Object Pooling để tối ưu hiệu năng
* Điều khiển nhân vật theo góc nhìn từ trên xuống (Top-down)

## Các kỹ thuật sử dụng

### Infinite Map

Map được tải và giải phóng động dựa trên vị trí của người chơi nhằm tạo cảm giác thế giới vô hạn.

### Enemy AI

Kẻ địch tự động xác định vị trí người chơi và di chuyển để tấn công.

### Object Pooling

Tái sử dụng Enemy và Bullet thay vì Instantiate/Destroy liên tục để giảm chi phí xử lý.

## Công nghệ sử dụng

* Unity
* C#

## Video và hình ảnh gameplay

https://drive.google.com/drive/u/1/folders/1XUNTT7WgJ9kRG4qJpRaHLkwv9z8BtUob

## Phiên bản Unity

Unity 2022.3
