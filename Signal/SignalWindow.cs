﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TatehamaATS.Database;
using TatehamaATS.DisplayLED;
using TatehamaATS.Exceptions;

namespace TatehamaATS.Signal
{

    public partial class SignalWindow : Form
    {
        public bool isShow;
        private Bitmap SignalImage;
        private SignalType NowSignalType;
        private SignalLight NowSignalLight;

        public SignalWindow()
        {
            InitializeComponent();
            TransparencyKey = BackColor;
            Show();

            Task.Run(() => StartUpdateLoop());
        }

        public void SignalHide()
        {
            Hide();
            isShow = false;
        }

        public void SignalShow()
        {
            if (this.IsDisposed)
            {
                Show();
                BringToFront();
                isShow = true;
            }
            else
            {
                Show();
                BringToFront();
                isShow = true;
            }
        }

        /// <summary>
        /// 非同期で表示器を更新するループを開始する
        /// </summary>
        private async void StartUpdateLoop()
        {
            while (true)
            {
                var timer = Task.Delay(15);
                try
                {
                    imageChenge();
                }
                catch (ATSCommonException ex)
                {
                    // ここで例外をキャッチしてログなどに出力する     
                    TrainState.ATSBroken = true;
                    Debug.WriteLine($"故障");
                    TrainState.ATSDisplay?.SetLED("", "");
                    TrainState.ATSDisplay?.AddState(ex.ToCode());
                    Debug.WriteLine($"{ex.Message}");
                }
                catch (Exception ex)
                {
                    // 他の例外もキャッチしてログなどに出力する     
                    TrainState.ATSBroken = true;
                    Debug.WriteLine($"{ex.Message}");
                    var e = new CsharpException(3, "", ex);
                    TrainState.ATSDisplay?.SetLED("", "");
                    TrainState.ATSDisplay?.AddState(e.ToCode());
                }
                await timer;
            }
        }

        private void imageChenge()
        {
            if (TrainState.NextTrack == null)
            {
                SignaiPic.BackgroundImage = Properties.Resources.signull;
                return;
            }
            //信号種類・信号現示に何らかの変化がない場合早期return
            if (TrainState.NextTrack.SignalType == NowSignalType && TrainState.NextTrack.Signal == NowSignalLight)
            {
                return;
            }

            //主信号
            switch (TrainState.NextTrack.SignalType)
            {
                case SignalType.Main_2Y:
                    switch (TrainState.NextTrack.Signal)
                    {
                        case SignalLight.R:
                            SignaiPic.BackgroundImage = Properties.Resources._2y_r;
                            break;
                        case SignalLight.Y:
                            SignaiPic.BackgroundImage = Properties.Resources._2y_y;
                            break;
                        default:
                            SignaiPic.BackgroundImage = Properties.Resources._2y_n;
                            break;
                    }
                    break;
                case SignalType.Main_3:
                    switch (TrainState.NextTrack.Signal)
                    {
                        case SignalLight.R:
                            SignaiPic.BackgroundImage = Properties.Resources._3nb_r;
                            break;
                        case SignalLight.Y:
                            SignaiPic.BackgroundImage = Properties.Resources._3nb_y;
                            break;
                        case SignalLight.G:
                            SignaiPic.BackgroundImage = Properties.Resources._3nb_g;
                            break;
                        default:
                            SignaiPic.BackgroundImage = Properties.Resources._3nb_n;
                            break;
                    }
                    break;
                case SignalType.Main_4yg:
                    switch (TrainState.NextTrack.Signal)
                    {
                        case SignalLight.R:
                            SignaiPic.BackgroundImage = Properties.Resources._4yg_r;
                            break;
                        case SignalLight.Y:
                            SignaiPic.BackgroundImage = Properties.Resources._4yg_y;
                            break;
                        case SignalLight.YG:
                            SignaiPic.BackgroundImage = Properties.Resources._4yg_yg;
                            break;
                        case SignalLight.G:
                            SignaiPic.BackgroundImage = Properties.Resources._4yg_g;
                            break;
                        default:
                            SignaiPic.BackgroundImage = Properties.Resources._4yg_n;
                            break;

                    }
                    break;
                case SignalType.Main_4yy:
                    switch (TrainState.NextTrack.Signal)
                    {
                        case SignalLight.R:
                            SignaiPic.BackgroundImage = Properties.Resources._4yy_r;
                            break;
                        case SignalLight.YY:
                            SignaiPic.BackgroundImage = Properties.Resources._4yy_yy;
                            break;
                        case SignalLight.Y:
                            SignaiPic.BackgroundImage = Properties.Resources._4yy_y;
                            break;
                        case SignalLight.G:
                            SignaiPic.BackgroundImage = Properties.Resources._4yy_g;
                            break;
                        default:
                            SignaiPic.BackgroundImage = Properties.Resources._4yy_n;
                            break;
                    }
                    break;
                case SignalType.Main_4yyng:
                    switch (TrainState.NextTrack.Signal)
                    {
                        case SignalLight.R:
                            SignaiPic.BackgroundImage = Properties.Resources._4yyng_r;
                            break;
                        case SignalLight.YY:
                            SignaiPic.BackgroundImage = Properties.Resources._4yyng_yy;
                            break;
                        case SignalLight.Y:
                            SignaiPic.BackgroundImage = Properties.Resources._4yyng_y;
                            break;
                        default:
                            SignaiPic.BackgroundImage = Properties.Resources._4yyng_n;
                            break;
                    }
                    break;
                case SignalType.Main_5:
                    switch (TrainState.NextTrack.Signal)
                    {
                        case SignalLight.R:
                            SignaiPic.BackgroundImage = Properties.Resources._5yg_r;
                            break;
                        case SignalLight.YY:
                            SignaiPic.BackgroundImage = Properties.Resources._5yg_yy;
                            break;
                        case SignalLight.Y:
                            SignaiPic.BackgroundImage = Properties.Resources._5yg_y;
                            break;
                        case SignalLight.YG:
                            SignaiPic.BackgroundImage = Properties.Resources._5yg_yg;
                            break;
                        case SignalLight.G:
                            SignaiPic.BackgroundImage = Properties.Resources._5yg_g;
                            break;
                        default:
                            SignaiPic.BackgroundImage = Properties.Resources._5yg_n;
                            break;
                    }
                    break;
                case SignalType.Switch_2:
                    switch (TrainState.NextTrack.Signal)
                    {
                        case SignalLight.R:
                            SignaiPic.BackgroundImage = Properties.Resources.sh_r;
                            break;
                        case SignalLight.G:
                            SignaiPic.BackgroundImage = Properties.Resources.sh_y;
                            break;
                        default:
                            SignaiPic.BackgroundImage = Properties.Resources.sh_n;
                            break;
                    }
                    break;
                default:
                    SignaiPic.BackgroundImage = Properties.Resources.co_n;
                    break;
            }
        }

        /// <summary>
        /// ウィンドウのドラッグ開始位置
        /// </summary>
        private Point dragStartPoint;

        /// <summary>
        /// マウスダウンイベントの処理
        /// </summary>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragStartPoint = e.Location;
            }
        }

        /// <summary>
        /// マウスムーブイベントの処理
        /// </summary>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Left + e.X - dragStartPoint.X, this.Top + e.Y - dragStartPoint.Y);
            }
        }
    }
}
