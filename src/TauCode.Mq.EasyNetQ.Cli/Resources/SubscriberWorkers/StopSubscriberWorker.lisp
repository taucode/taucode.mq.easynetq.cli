(defblock :name stop-subscriber :is-top t
	(worker
		:worker-name stop-subscriber
		:verb "stop"
		:description "Stops the subscriber."
		:usage-samples (
			"sub stop"))

	(end)
)
