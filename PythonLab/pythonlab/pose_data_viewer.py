import argparse
from pathlib import Path

import numpy as np
import plotly.graph_objects as go

parser = argparse.ArgumentParser(description='Display pose data as 3D scatter')
parser.add_argument('input_path', type=Path, help='Path to the input pose data file')
args = parser.parse_args()

input_path: Path = args.input_path

def load_pose_data(path: Path):
    data = []
    with open(path, "r") as f:
        for line in f:
            coordinates = []
            for coord_str in line.strip().split():
                x, y, z = map(float, coord_str.split(","))
                coordinates.append([x, y, z])
            data.append(coordinates)

    matrix = np.array(data)
    return matrix

data = load_pose_data(input_path)[:10]

# n, m = 10, 100
# data = np.random.rand(n, m, 3)

# Figureを作成
fig = go.Figure(
    frames=[
        go.Frame(
            data=[go.Scatter3d(x=data[k, :, 0], y=data[k, :, 1], z=data[k, :, 2], mode="markers")],
            name=str(k),
        )
        for k in range(data.shape[0])
    ]
)

min_x = np.min(data[:, :, 0])
max_x = np.max(data[:, :, 0])
min_y = np.min(data[:, :, 1])
max_y = np.max(data[:, :, 1])
min_z = np.min(data[:, :, 2])
max_z = np.max(data[:, :, 2])

center_x = (min_x + max_x) / 2
center_y = (min_y + max_y) / 2
center_z = (min_z + max_z) / 2

radius = max(
    max_x - min_x,
    max_y - min_y,
    max_z - min_z,
    ) / 2

# 初期フレームを設定
fig.add_trace(go.Scatter3d(x=data[0, :, 0], y=data[0, :, 1], z=data[0, :, 2], mode="markers"))

# アニメーションの設定
fig.update_layout(
    updatemenus=[
        dict(
            type="buttons",
            buttons=[
                dict(label="再生", method="animate", args=[None]),
                dict(
                    label="一時停止",
                    method="animate",
                    args=[
                        [None],
                        {
                            "frame": {"duration": 0, "redraw": False},
                            "fromcurrent": True,
                            "transition": {"duration": 0},
                        },
                    ],
                ),
            ],
        )
    ],
    scene=dict(
        xaxis=dict(range=[center_x - radius,  center_x + radius]),
        yaxis=dict(range=[center_y - radius,  center_y + radius]),
        zaxis=dict(range=[center_z - radius,  center_z + radius]),
    ),
)

fig.show()
