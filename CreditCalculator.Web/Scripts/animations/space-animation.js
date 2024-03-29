// adapted from https://www.contextfreeart.org/gallery2/index.html#design/805
// Organic tree by curran, July 27th, 2007
"use strict";
const cfa = {
    canvas: document.querySelector("canvas"),
    queue: [],
    init(p) {
        this.ctx = this.canvas.getContext("2d");
        this.width = this.canvas.width = this.canvas.offsetWidth * 2;
        this.height = this.canvas.height = this.canvas.offsetHeight * 2;
        this.ctx.fillStyle = p.background || "#000";
        this.ctx.fillRect(0, 0, this.width, this.height);
        this.rect = [0, 0, 0, 0];
        this.queue.length = 0;
        this.scale = 500;
        this.speed = p.speed || 100;
        this.minSize = p.minSize || 2;
        this.iter = this.run();
    },
    ajustments: {
        x(m, v) {
            m[4] += v * m[0];
            m[5] += v * m[1];
        },
        y(m, v) {
            m[4] += v * m[2];
            m[5] += v * m[3];
        },
        rotate(m, v) {
            const cos = Math.cos(Math.PI * v / 180);
            const sin = Math.sin(Math.PI * v / 180);
            const r00 = cos * m[0] + sin * m[2];
            const r01 = cos * m[1] + sin * m[3];
            m[2] = cos * m[2] - sin * m[0];
            m[3] = cos * m[3] - sin * m[1];
            m[0] = r00;
            m[1] = r01;
        },
        scale(m, v) {
            let x, y;
            if (Array.isArray(v)) {
                x = v[0];
                y = v[1];
            } else {
                x = v;
                y = x;
            }
            m[0] *= x;
            m[1] *= x;
            m[2] *= y;
            m[3] *= y;
        },
        hue(m, v) {
            m[6] += v;
            m[6] %= 360;
        },
        sat(m, v) {
            this.adjustColor(m, v, 7);
        },
        bri(m, v) {
            this.adjustColor(m, v, 8);
        },
        alpha(m, v) {
            this.adjustColor(m, v, 9);
        },
        adjustColor(m, v, p) {
            let c = m[p] + Math.abs(v) * ((v < 0 ? 0 : 1) - m[p]);
            if (c < 0) c = 0;
            else if (c > 1) c = 1;
            m[p] = c;
        }
    },
    adjust(s, p) {
        const m = s.slice();
        for (const c in p) {
            this.ajustments[c](m, p[c]);
        }
        return m;
    },
    setTransform(s) {
        this.ctx.setTransform(
            -this.scale * s[0],
            this.scale * s[1],
            this.scale * s[2],
            -this.scale * s[3],
            this.scale * s[4] + this.offsetX,
            -this.scale * s[5] + this.offsetY
        );
    },
    CIRCLE(s, p) {
        s = this.adjust(s, p);
        cfa.queue.push([s, "circle"]);
        cfa.boundingRect(s);
    },
    SQUARE(s, p) {
        s = this.adjust(s, p);
        cfa.queue.push([s, "square"]);
        cfa.boundingRect(s);
    },
    circle(s) {
        this.setTransform(s);
        this.fillStyle(s);
        this.ctx.beginPath();
        this.ctx.arc(0, 0, 0.5, 0, 2 * Math.PI);
        this.ctx.fill();
    },
    square(s) {
        this.setTransform(s);
        this.fillStyle(s);
        this.ctx.fillRect(-0.5, -0.5, 1, 1);
    },
    fillStyle(s) {
        const light = (2 - s[7]) * (s[8] * 0.5);
        const sat = light <= 1 ? s[7] * s[8] / light : s[7] * s[8] / (2 - light);
        this.ctx.fillStyle = `hsla(${s[6]},${sat * 100}%,${light * 100}%,${s[9]})`;
        //this.ctx.fillStyle = `hsla(${125},${84}%,${41}%,${1})`;
        //this.ctx.fillStyle = `hsla(${0},${0}%,${100}%,${1})`;

    },
    boundingRect(s) {
        const x = s[4] * this.scale;
        const y = s[5] * this.scale;
        if (x < this.rect[0]) this.rect[0] = x;
        else if (x > this.rect[1]) this.rect[1] = x;
        if (y < this.rect[2]) this.rect[2] = y;
        else if (y > this.rect[3]) this.rect[3] = y;
    },
    center(s) {
        const br = this.rect;
        const scale =
            Math.min(this.width / (br[1] - br[0]), this.height / (br[3] - br[2])) * s;
        this.scale *= scale;
        this.offsetX = this.width * 0.5 - (br[0] + br[1]) * 0.5 * scale;
        this.offsetY = this.height * 0.5 + (br[3] + br[2]) * 0.5 * scale;
    },
    execRule(s, p, rules) {
        s = this.adjust(s, p);
        if (
            Math.abs(s[1]) * this.scale < this.minSize &&
            Math.abs(s[3]) * this.scale < this.minSize
        )
            return;
        let totalWeight = 0;
        for (const rule of rules) totalWeight += rule.weight || 1.0;
        let weight = 0,
            rnd = Math.random() * totalWeight;
        for (const rule of rules) {
            weight += rule.weight || 1.0;
            if (rnd <= weight) {
                rule.exec(s);
                break;
            }
        }
    },
    *run() {
        let s = 0;
        for (const draw of this.queue) {
            this[draw[1]](draw[0]);
            if (s++ > this.speed) {
                s = 0;
                yield requestAnimationFrame(_ => this.iter.next());
            }
        }
    },
    render() {
        this.iter.return();
        this.iter = this.run();
        this.iter.next();
    }
};
["click", "touchdown"].forEach(event => {
    document.addEventListener(event, e => start(), false);
});
/////////////////////////////////////////////
const TREE = (s, p) => {
    cfa.execRule(s, p, [
        {
            weight: 20,
            exec(s) {
                cfa.CIRCLE(s, { scale: 0.35 });
                SCRAGGLE(s, { y: 0.1 });
            }
        },
        {
            weight: 1,
            exec(s) {
                BRANCH(s, { scale: 0.7 });
            }
        }
    ]);
};
const SCRAGGLE = (s, p) => {
    cfa.execRule(s, p, [
        {
            exec(s) {
                TREE(s, { rotate: 8 });
            }
        },
        {
            exec(s) {
                TREE(s, { rotate: -8 });
            }
        }
    ]);
};
const BRANCH = (s, p) => {
    cfa.execRule(s, p, [
        {
            exec(s) {
                TREE(s, { rotate: -10 });
                TREE(s, { rotate: 10 });
            }
        }
    ]);
};
/////////////////////////////////////////////
const start = () => {
    cfa.init({
        background: "#fff",
        speed: window.location.href.indexOf("fullcpgrid") > -1 ? 5000 : 500,
        minSize: 4
    });
    TREE([1, 0, 0, 1, 0, 0, 0, 0, 0.01, 1]);
    cfa.center(1);
    const h = cfa.height * 0.8;
    const w = Math.min(cfa.height, cfa.width) * 0.25;
    const grd = cfa.ctx.createLinearGradient(w * 0.5, 0, w * 0.5, h);
    //grd.addColorStop(0, "rgba(255, 182, 0, 1)");
    //grd.addColorStop(1, "rgba(107, 29, 29, 1)");
    cfa.ctx.save();
    cfa.ctx.translate(cfa.offsetX - w * 0.5, cfa.offsetY - h + cfa.scale * 0.25);
    cfa.ctx.fillStyle = grd;
    cfa.ctx.fillRect(0, 0, w, h);
    cfa.ctx.restore();
    cfa.render();
};
start();
